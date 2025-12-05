using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Security.Principal;




namespace ProcessManagerApp
{
    public partial class EventLogForm : Form
    {
        public EventLogForm()
        {
            InitializeComponent();
        }

        private void LoadEventLogs(string logName)
        {

            dataGridLogs.Rows.Clear();
            int rowIndex = 1;

            // Перевірка на доступ до журналу Security
            if (logName == "Security" && !IsRunningAsAdmin())
            {
                MessageBox.Show("Щоб переглядати журнал 'Security', запустіть програму від імені адміністратора.",
                                "Недостатньо прав", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                EventLog log = new EventLog(logName);
                //int maxCount = (int)numLimit.Value;

                // Діапазон фільтрації
                var fromDate = dtpFrom.Value.Date;
                var toDate = dtpTo.Value.Date.AddDays(1); // включно до кінця доби

                //var entries = log.Entries.Cast<EventLogEntry>().Reverse().Take(100);
                var entries = log.Entries.Cast<EventLogEntry>()
                    .Where(e => e.TimeGenerated >= fromDate && e.TimeGenerated < toDate)
                    .Reverse(); // найновіші першими
                               //.Take(100);
                     //.Take(maxCount);

                foreach (var entry in entries)
                {
                    dataGridLogs.Rows.Add(
                        rowIndex++, // Номер рядка
                        entry.TimeGenerated.ToString("yyyy-MM-dd HH:mm:ss"),
                        entry.EntryType.ToString(),
                        entry.Source,
                        entry.Message.Length > 200 ? entry.Message.Substring(0, 200) + "..." : entry.Message
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка: " + ex.Message);
            }
        }

        private void EventLogForm_Load(object sender, EventArgs e)
        {
            ////завантаження всхі типів логів 
            cmbLogType.Items.Clear(); // Очистити на всяк випадок

            // Додаємо всі доступні типи логів з системи
            foreach (var log in EventLog.GetEventLogs())
            {
                cmbLogType.Items.Add(log.Log);
            }


            dataGridLogs.Columns.Add("Index", "№");
            dataGridLogs.Columns.Add("Time", "Час");
            dataGridLogs.Columns.Add("Type", "Тип");
            dataGridLogs.Columns.Add("Source", "Джерело");
            dataGridLogs.Columns.Add("Message", "Повідомлення");
            dataGridLogs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;



            // Автоматична ширина для перших трьох колонок
            dataGridLogs.Columns["Index"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridLogs.Columns["Time"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridLogs.Columns["Type"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridLogs.Columns["Source"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridLogs.Columns["Message"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridLogs.ReadOnly = true;
            dataGridLogs.AllowUserToAddRows = false;
            dataGridLogs.RowHeadersVisible = false; //  сховати ліву пусту ц колонку


            // Встановлюємо діапазон дати за замовчуванням (сьогодні)
            dtpFrom.Value = DateTime.Today;
            dtpTo.Value = DateTime.Today;

            // Якщо є хоча б один лог — вибрати перший
            if (cmbLogType.Items.Count > 0)
            {
                cmbLogType.SelectedIndex = 0;
                LoadEventLogs(cmbLogType.SelectedItem.ToString()); // одразу завантажити логи
            }

        }

        private void btnLoadLogs_Click(object sender, EventArgs e)
        {
            LoadEventLogs(cmbLogType.SelectedItem.ToString());
        }

        private bool IsRunningAsAdmin()
        {
            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
    }
}

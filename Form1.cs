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

namespace ProcessManagerApp
{
    public partial class Form1: Form
    {
        private Dictionary<int, TimeSpan> prevCpuTimes = new Dictionary<int, TimeSpan>();
        private DateTime lastCpuMeasureTime = DateTime.Now;
        public Form1()
        {
            InitializeComponent();

        }

        private int currentInterval = 2000; // у мс, 2 секунди — початково
        private void Form1_Load(object sender, EventArgs e)
        {
            txtSearch.Text = "Поле для пошуку по назві процесу";
            txtSearch.ForeColor = Color.Gray;

            dataGridProcesses.RowHeadersVisible = false; //  сховати ліву колонку
            // Налаштування DataGridView (одноразово)
            dataGridProcesses.Columns.Clear();

            // ДОДАНО — управління висотою та автозаповненням колонок
            dataGridProcesses.RowTemplate.Height = 24;
            dataGridProcesses.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dataGridProcesses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            

            // Назва процесу
            var colName = new DataGridViewTextBoxColumn();
            colName.HeaderText = "Назва процесу";
            colName.Name = "ProcessName";
            dataGridProcesses.Columns.Add(colName);

            // ID
            var colId = new DataGridViewTextBoxColumn();
            colId.HeaderText = "ID";
            colId.Name = "Id";
            colId.ValueType = typeof(int);
            dataGridProcesses.Columns.Add(colId);

            // Пам’ять (MB)
            var colMemory = new DataGridViewTextBoxColumn();
            colMemory.HeaderText = "Пам’ять (MB)";
            colMemory.Name = "Memory";
            colMemory.ValueType = typeof(double);
            dataGridProcesses.Columns.Add(colMemory);

            //// CPU (%)
            //var colCpu = new DataGridViewTextBoxColumn();
            //colCpu.HeaderText = "CPU (%)";
            //colCpu.Name = "Cpu";
            //colCpu.ValueType = typeof(double);
            //dataGridProcesses.Columns.Add(colCpu);


            // Час запуску
            var colStartTime = new DataGridViewTextBoxColumn();
            colStartTime.HeaderText = "Час запуску";
            colStartTime.Name = "StartTime";
            dataGridProcesses.Columns.Add(colStartTime);

            // Заголовок вікна
            var colTitle = new DataGridViewTextBoxColumn();
            colTitle.HeaderText = "Заголовок вікна";
            colTitle.Name = "WindowTitle";
            dataGridProcesses.Columns.Add(colTitle);

            // Шлях до файлу
            var colPath = new DataGridViewTextBoxColumn();
            colPath.HeaderText = "Шлях до файлу";
            colPath.Name = "Path";
            dataGridProcesses.Columns.Add(colPath);

            // Пріоритет
            var colPriority = new DataGridViewTextBoxColumn();
            colPriority.HeaderText = "Пріоритет";
            colPriority.Name = "Priority";
            dataGridProcesses.Columns.Add(colPriority);


            dataGridProcesses.Columns["Memory"].DefaultCellStyle.Format = "F2"; // 2 знаки після коми
            //dataGridProcesses.Columns["Cpu"].DefaultCellStyle.Format = "F1";    // 1 знак після коми


            dataGridProcesses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridProcesses.MultiSelect = false;
            dataGridProcesses.ReadOnly = true;
            dataGridProcesses.AllowUserToAddRows = false;
            dataGridProcesses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            // Завантаження процесів при старті
            LoadProcesses();

            // Налаштування таймера
            refreshTimer.Interval = currentInterval;
            txtInterval.Text = (currentInterval / 1000).ToString();
            refreshTimer.Tick += refreshTimer_Tick;
            refreshTimer.Start();
        }

        private void LoadProcesses()
        {

            //  Збереження: Сортування
            string sortedColumn = dataGridProcesses.SortedColumn?.Name;
            SortOrder sortOrder = dataGridProcesses.SortOrder;

            //  Виділення
            int? selectedId = null;
            if (dataGridProcesses.SelectedRows.Count > 0)
            {
                selectedId = Convert.ToInt32(dataGridProcesses.SelectedRows[0].Cells["Id"].Value);
            }

            //  Скрол
            int scrollIndex = dataGridProcesses.FirstDisplayedScrollingRowIndex;



            dataGridProcesses.Rows.Clear();
            var processes = Process.GetProcesses();
            double totalMemoryMb = 0;

            DateTime now = DateTime.Now;
            double intervalSeconds = (now - lastCpuMeasureTime).TotalSeconds;
            lastCpuMeasureTime = now;

            foreach (var process in processes)
            {
                try
                {
                    //double cpuUsage = 0;
                    //TimeSpan currentCpuTime = process.TotalProcessorTime;

                    //if (prevCpuTimes.TryGetValue(process.Id, out TimeSpan prevCpuTime) && intervalSeconds > 0)
                    //{
                    //    TimeSpan cpuDelta = currentCpuTime - prevCpuTime;

                    //    // Розрахунок % CPU
                    //    cpuUsage = cpuDelta.TotalMilliseconds / (Environment.ProcessorCount * intervalSeconds * 1000.0) * 100.0;
                    //}
                    //// Оновлюємо збережене значення
                    //prevCpuTimes[process.Id] = currentCpuTime;

                    double memMb = process.WorkingSet64 / 1024.0 / 1024.0;
                    totalMemoryMb += memMb;

                    string startTime = "";
                    string windowTitle = process.MainWindowTitle;
                    string filePath = "";
                    string priority = "";

                    try
                    {
                        startTime = process.StartTime.ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    catch { startTime = "—"; }

                    try
                    {
                        filePath = process.MainModule.FileName;
                    }
                    catch { filePath = "Немає доступу"; }

                    try
                    {
                        priority = process.PriorityClass.ToString();
                    }
                    catch { priority = "—"; }


                    dataGridProcesses.Rows.Add(
                        process.ProcessName,
                        process.Id,    
                        memMb,         // передаємо як число (тип double)
                                       //cpuUsage       // також число
                        startTime,
                        windowTitle,
                        filePath,
                        priority
                    );
                }
                catch { /* Деякі процеси можуть бути недоступні */ }
            }

            lblTotal.Text = $"Загальна кількість процесів: {processes.Length}";
            lblMemory.Text = $"Загальна використана пам’ять: {totalMemoryMb:F2} MB";

                      

            //  Відновлення: сортування
            if (!string.IsNullOrEmpty(sortedColumn))
            {
                var direction = sortOrder == SortOrder.Descending
                    ? ListSortDirection.Descending
                    : ListSortDirection.Ascending;

                dataGridProcesses.Sort(dataGridProcesses.Columns[sortedColumn], direction);
            }

            //  Відновлення виділення
            if (selectedId != null)
            {
                dataGridProcesses.ClearSelection();

                foreach (DataGridViewRow row in dataGridProcesses.Rows)
                {
                    if (Convert.ToInt32(row.Cells["Id"].Value) == selectedId)
                    {
                        row.Selected = true;
                        break;
                    }
                }
            }

            //  Відновлення прокрутки
            this.BeginInvoke(new MethodInvoker(() =>
            {
                if (scrollIndex >= 0 && scrollIndex < dataGridProcesses.RowCount)
                {
                    dataGridProcesses.FirstDisplayedScrollingRowIndex = scrollIndex;
                }
            }));



        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadProcesses();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string search = txtSearch.Text.ToLower();

            foreach (DataGridViewRow row in dataGridProcesses.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    row.Visible = row.Cells[0].Value.ToString().ToLower().Contains(search);
                }
            }
        }

        private void btnKill_Click(object sender, EventArgs e)
        {
            if (dataGridProcesses.SelectedRows.Count > 0)
            {
                int pid = int.Parse(dataGridProcesses.SelectedRows[0].Cells[1].Value.ToString());

                try
                {
                    Process.GetProcessById(pid).Kill();
                    MessageBox.Show("Процес завершено.");
                    LoadProcesses();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка: {ex.Message}");
                }
            }
        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            LoadProcesses();
            Debug.WriteLine($"Оновлено: {DateTime.Now}");

        }

        private void btnSetInterval_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtInterval.Text, out int seconds) && seconds > 0)
            {
                //refreshTimer.Interval = seconds * 1000; // переведення в мілісекунди

                currentInterval = seconds * 1000;
                refreshTimer.Stop();
                refreshTimer.Interval = currentInterval;
                refreshTimer.Start();

                MessageBox.Show($"Інтервал оновлення встановлено: {seconds} сек.");

            }
            else
            {
                MessageBox.Show("Введіть коректне число більше 0.");
            }
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Поле для пошуку по назві процесу")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "Поле для пошуку по назві процесу";
                txtSearch.ForeColor = Color.Gray;
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch.PerformClick(); // або btnSearch_Click(sender, e);
                e.SuppressKeyPress = true; // Щоб не писав "дзвінок" Enter
            }
        }

        private void txtInterval_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSetInterval.PerformClick(); // або btnSetInterval_Click(sender, e);
                e.SuppressKeyPress = true;
            }
        }








    }
}

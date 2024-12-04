using System;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out int n) || n <= 0)
            {
                MessageBox.Show("Введіть коректне значення n (ціле число більше нуля)!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double[] array = new double[n];
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                array[i] = Math.Round(rnd.NextDouble() * (18.3 - (-14.2)) + (-14.2), 1);
            }

            listBox1.Items.Clear();
            listBox1.Items.Add("Початковий масив:");
            listBox1.Items.Add(string.Join(" ", array.Select(x => x.ToString("F1"))));

            int minIndex = Array.IndexOf(array, array.Min());
            int maxIndex = Array.IndexOf(array, array.Max());
            if (minIndex > maxIndex)
            {
                (minIndex, maxIndex) = (maxIndex, minIndex);
            }
            int sumIndexes = Enumerable.Range(minIndex + 1, maxIndex - minIndex - 1).Sum();

            if (maxIndex - minIndex > 1)
            {
                Array.Reverse(array, minIndex + 1, maxIndex - minIndex - 1);
            }

            listBox2.Items.Clear();
            listBox2.Items.Add($"Сума індексів між мінімальним ({array[minIndex]:F1}) та максимальним ({array[maxIndex]:F1}): {sumIndexes}");
            listBox2.Items.Add("Масив після зміни порядку між мінімумом та максимумом:");
            listBox2.Items.Add(string.Join(" ", array.Select(x => x.ToString("F1"))));
        }
    }
}

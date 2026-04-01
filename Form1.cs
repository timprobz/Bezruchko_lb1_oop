using System.Windows.Forms;
using System.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;
namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        private void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;

            // Дозволяємо цифри, керуючі символи, мінус та кому
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || Char.IsControl(e.KeyChar))
            {
                return;
            }

            // Заміна крапки на кому
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }

            // Перевірка на дублювання коми
            if (e.KeyChar == ',')
            {
                if (txt.Text.IndexOf(',') != -1)
                {
                    e.Handled = true; // Кома вже є
                }
                return;
            }

            // Перевірка на мінус (дозволено лише першим символом)
            if (e.KeyChar == '-')
            {
                if (txt.Text.Length > 0 && txt.SelectionStart != 0)
                {
                    e.Handled = true;
                }
                return;
            }

            // Інші символи заборонені
            e.Handled = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double a = Convert.ToDouble(txtA.Text);
                double b = Convert.ToDouble(txtB.Text);
                double c = Convert.ToDouble(txtC.Text);
                double d = Convert.ToDouble(txtD.Text);

                if (b == 0 || d == 0 || c == 0)
                {
                    MessageBox.Show("Помилка: ділення на нуль неможливе!");
                    return;
                }

                double result = (a / b) * (b / d) - ((a * b) - c) / (c * d);
                label1.Text = "Результат: " + result.ToString("F4");
            }
            catch (FormatException)
            {
                MessageBox.Show("Введіть коректні числа.");
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtA_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                double v = Convert.ToDouble(textBox1.Text);
                double v1 = Convert.ToDouble(textBox2.Text);
                double t1 = Convert.ToDouble(textBox3.Text);
                double t2 = Convert.ToDouble(textBox4.Text);

                if (v <= 0 || v1 < 0 || t1 < 0 || t2 < 0)
                {
                    MessageBox.Show("Швидкість та час не можуть бути від'ємними.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Шлях по озеру (стояча вода)
                double sLake = v * t1;
                // Шлях проти течії (швидкість човна мінус швидкість течії)
                double sRiver = (v - v1) * t2;

                double totalDistance = sLake + sRiver;

                label2.Text = "Загальний шлях: " + totalDistance.ToString("F2") + " км";
            }
            catch (FormatException)
            {
                MessageBox.Show("Введіть коректні числа.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int N = Convert.ToInt32(textBox5.Text);

                // Перевірка, чи число є тризначним (враховуючи від'ємні)
                if (Math.Abs(N) < 100 || Math.Abs(N) > 999)
                {
                    MessageBox.Show("Будь ласка, введіть тризначне число.", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int absN = Math.Abs(N);
                int digit1 = absN / 100;
                int digit2 = (absN / 10) % 10;
                int digit3 = absN % 10;

                int sum = digit1 + digit2 + digit3;
                bool isEven = (sum % 2 == 0);

                label7.Text = "Результат: " + isEven.ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Введіть ціле число.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                
                double x1 = Convert.ToDouble(txtX1.Text); double y1 = Convert.ToDouble(txtY1.Text);
                double x2 = Convert.ToDouble(txtX2.Text); double y2 = Convert.ToDouble(txtY2.Text);
                double x3 = Convert.ToDouble(txtX3.Text); double y3 = Convert.ToDouble(txtY3.Text);
                double x4 = Convert.ToDouble(txtX4.Text); double y4 = Convert.ToDouble(txtY4.Text);

                
                double z1 = (x2 - x1) * (y3 - y2) - (y2 - y1) * (x3 - x2);
                double z2 = (x3 - x2) * (y4 - y3) - (y3 - y2) * (x4 - x3);
                double z3 = (x4 - x3) * (y1 - y4) - (y4 - y3) * (x1 - x4);
                double z4 = (x1 - x4) * (y2 - y1) - (y1 - y4) * (x2 - x1);

                
                bool isConvex = (z1 > 0 && z2 > 0 && z3 > 0 && z4 > 0) || (z1 < 0 && z2 < 0 && z3 < 0 && z4 < 0);

                if (isConvex)
                    label8.Text = "Чотирикутник є опуклим.";
                else
                    label8.Text = "Чотирикутник НЕ є опуклим.";
            }
            catch (FormatException)
            {
                MessageBox.Show("Перевірте правильність введення координат.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                int a = Convert.ToInt32(textBox6.Text);
                int b = Convert.ToInt32(textBox7.Text);
                int c = Convert.ToInt32(textBox8.Text);
                int d = Convert.ToInt32(textBox9.Text);

                if (a == 0 || d == 0)
                {
                    MessageBox.Show("Коефіцієнти 'a' та 'd' не можуть дорівнювати нулю.", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                listBox1.Items.Clear(); 
                int absD = Math.Abs(d);
                bool found = false;

                
                for (int i = 1; i <= absD; i++)
                {
                    if (absD % i == 0)
                    {
                        
                        if (a * Math.Pow(i, 3) + b * Math.Pow(i, 2) + c * i + d == 0)
                        {
                            listBox1.Items.Add(i);
                            found = true;
                        }
                        
                        if (a * Math.Pow(-i, 3) + b * Math.Pow(-i, 2) + c * (-i) + d == 0)
                        {
                            listBox1.Items.Add(-i);
                            found = true;
                        }
                    }
                }

                if (!found)
                    listBox1.Items.Add("Цілих коренів не знайдено.");
            }
            catch (FormatException)
            {
                MessageBox.Show("Введіть цілі числа.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                
                string[] strArrA = textBoxArrayA.Text.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                string[] strArrB = textBoxArrayB.Text.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                
                int[] A = strArrA.Select(int.Parse).ToArray();
                int[] B = strArrB.Select(int.Parse).ToArray();

                if (B.Length >= A.Length)
                {
                    MessageBox.Show("Довжина другої послідовності має бути меншою за першу (m < n).", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                
                bool allExist = true;
                foreach (int item in B)
                {
                    if (!A.Contains(item))
                    {
                        allExist = false;
                        break;
                    }
                }

                if (allExist)
                    label10.Text = "Всі елементи другої послідовності входять в першу.";
                else
                    label10.Text = "НЕ всі елементи другої послідовності входять в першу.";
            }
            catch (FormatException)
            {
                MessageBox.Show("Введіть коректні цілі числа через пробіл або кому.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                string text = textBoxText.Text;

                
                char[] separators = new char[] { ' ', '.', ',', '!', '?', ';', ':', '\n', '\r' };
                string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                int count = 0;

                foreach (string word in words)
                {
                    
                    if (word.StartsWith("b", StringComparison.OrdinalIgnoreCase))
                    {
                        count++;
                    }
                }

                label11.Text = $"Кількість слів на букву 'b': {count}";
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Сталася помилка при обробці тексту: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

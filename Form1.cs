using System;
using System.IO;
using System.Windows.Forms;

namespace vlad_summer_prack
{
    struct Info
    {
        public string full_name;
        public string role;
        public string height;
        public string weight;
        public string reference_year;
        public string number_goals_scored;
        public string penalty;
        public string number_deletions;
        public string number_minutes_field;
    }
    public partial class Form1 : Form
    {
        Info command;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string line = "";
            using (StreamReader file = new StreamReader("command.txt"))
            {
                while ((line = file.ReadLine()) != null)
                {
                    string[] str_arr = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (str_arr.Length!=0)
                    {
                        command.full_name = str_arr[0] + " " + str_arr[1] + " " + str_arr[2];
                        command.role = str_arr[3];
                        command.height = str_arr[4];
                        command.weight = str_arr[5];
                        command.reference_year = str_arr[6];
                        command.number_goals_scored = str_arr[7];
                        command.penalty = str_arr[8];
                        command.number_deletions = str_arr[9];
                        command.number_minutes_field = str_arr[10];
                        string[] row = new string[] { command.full_name, command.role, command.height, command.weight, command.reference_year, command.number_goals_scored, command.penalty, command.number_deletions, command.number_minutes_field };
                        dataGridView1.Rows.Add(row);
                    }
                   
                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            dataGridView2.Rows.Add();
            string line = "";
            using (StreamReader file = new StreamReader("command.txt"))
            {
                while ((line = file.ReadLine()) != null)
                {
                    
                    string[] str_arr = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (str_arr.Length!=0)
                    {
                        command.full_name = str_arr[0] + " " + str_arr[1] + " " + str_arr[2];
                        command.role = str_arr[3];
                        command.height = str_arr[4];
                        command.weight = str_arr[5];
                        command.reference_year = str_arr[6];
                        command.number_goals_scored = str_arr[7];
                        command.penalty = str_arr[8];
                        command.number_deletions = str_arr[9];
                        command.number_minutes_field = str_arr[10];
                        string[] row = new string[] { command.full_name, command.role, command.height, command.weight, command.reference_year, command.number_goals_scored, command.penalty, command.number_deletions, command.number_minutes_field };
                        dataGridView1.Rows.Add(row);
                    }
                    
                }
            }
            dataGridView4.Rows.Clear();
            line = "";
            using (StreamReader file = new StreamReader("command.txt"))
            {
                while ((line = file.ReadLine()) != null)
                {
                    string[] str_arr = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (str_arr.Length != 0)
                    {
                        command.full_name = str_arr[0] + " " + str_arr[1] + " " + str_arr[2];
                        command.role = str_arr[3];
                        command.height = str_arr[4];
                        command.weight = str_arr[5];
                        command.reference_year = str_arr[6];
                        command.number_goals_scored = str_arr[7];
                        command.penalty = str_arr[8];
                        command.number_deletions = str_arr[9];
                        command.number_minutes_field = str_arr[10];
                        string[] row = new string[] { command.full_name, command.role, command.height, command.weight, command.reference_year, command.number_goals_scored, command.penalty, command.number_deletions, command.number_minutes_field };
                        dataGridView1.Rows.Add(row);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool mus_flag = true;
            for (int i = 0; i < 9; i++)
            {
                ///блок проверки на ошибки


                switch (i)
                {
                    case 0:
                        try
                        {
                            string line = dataGridView2[i, 0].Value.ToString();
                            string[] str_arr = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            bool flag = false;
                            for (int j = 0; j < line.Length; j++)
                            {
                                flag = char.IsNumber(line[j]);
                            }
                            if ((str_arr.Length != 3) || (flag))
                            {
                                MessageBox.Show("Ошибка в графе ФИО");
                                mus_flag = false;
                            }
                        }
                        catch (NullReferenceException)
                        {

                            MessageBox.Show("Ошибка в графе ФИО");
                            mus_flag = false;
                        }

                        break;
                    case 1:
                        try
                        {

                            string line = dataGridView2[i, 0].Value.ToString();
                            string[] str_arr = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            bool flag = false;
                            for (int j = 0; j < line.Length; j++)
                            {
                                flag = char.IsNumber(line[j]);
                            }
                            if ((flag) || ((line != "Вратарь") && (line != "Нападающий") && (line != "Защитник")))
                            {
                                MessageBox.Show("Ошибка в графе Амплуа");
                                mus_flag = false;
                            }
                        }
                        catch (NullReferenceException)
                        {

                            MessageBox.Show("Ошибка в графе Амплуа");
                            mus_flag = false;
                        }

                        break;
                    case 2:
                        try
                        {
                            int height = Convert.ToInt32(dataGridView2[i, 0].Value);
                            if (height < 50 || height > 251)
                            {
                                MessageBox.Show("Ошибка в графе Рост");
                                mus_flag = false;
                            }
                        }
                        catch (NullReferenceException)
                        {
                            MessageBox.Show("Ошибка в графе Рост");
                            mus_flag = false;
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Ошибка в графе Рост");
                            mus_flag = false;
                        }
                        break;
                    case 3:

                        try
                        {
                            int weight = Convert.ToInt32(dataGridView2[i, 0].Value);
                            if (weight < 50 || weight > 150)
                            {
                                MessageBox.Show("Ошибка в графе Вес");
                                mus_flag = false;
                            }
                        }
                        catch (NullReferenceException)
                        {
                            MessageBox.Show("Ошибка в графе Вес");
                            mus_flag = false;
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Ошибка в графе Вес");
                            mus_flag = false;
                        }


                        break;
                    case 4:
                        try
                        {
                            int year = Convert.ToInt32(dataGridView2[i, 0].Value);
                            if (year < 0 || year > 2023)
                            {
                                MessageBox.Show("Ошибка в графе Контрольный год");
                                mus_flag = false;
                            }
                        }
                        catch (NullReferenceException)
                        {
                            MessageBox.Show("Ошибка в графе Контрольный год");
                            mus_flag = false;
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Ошибка в графе Контрольный год");
                            mus_flag = false;
                        }

                        break;
                    case 5:
                        try
                        {
                            int goal = Convert.ToInt32(dataGridView2[i, 0].Value);
                            if (goal < 0)
                            {
                                MessageBox.Show("Ошибка в графе Количество забитых шайб");
                                mus_flag = false;
                            }
                        }
                        catch (NullReferenceException)
                        {
                            MessageBox.Show("Ошибка в графе Количество забитых шайб");
                            mus_flag = false;
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Ошибка в графе Количество забитых шайб");
                            mus_flag = false;
                        }

                        break;
                    case 6:
                        try
                        {
                            int penalty = Convert.ToInt32(dataGridView2[i, 0].Value);
                            if (penalty < 0)
                            {
                                MessageBox.Show("Ошибка в графе Штраф");
                                mus_flag = false;
                            }
                        }
                        catch (NullReferenceException)
                        {
                            MessageBox.Show("Ошибка в графе Штраф");
                            mus_flag = false;
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Ошибка в графе Штраф");
                            mus_flag = false;
                        }


                        break;
                    case 7:
                        try
                        {
                            int delet = Convert.ToInt32(dataGridView2[i, 0].Value);
                            if (delet < 0)
                            {
                                MessageBox.Show("Ошибка в графе Количество удалений");
                                mus_flag = false;
                            }
                        }
                        catch (NullReferenceException)
                        {
                            MessageBox.Show("Ошибка в графе Количество удалений");
                            mus_flag = false;
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Ошибка в графе Количество удалений");
                            mus_flag = false;
                        }
                        break;
                    case 8:
                        try
                        {
                            int field = Convert.ToInt32(dataGridView2[i, 0].Value);
                            if (field < 0)
                            {
                                MessageBox.Show("Ошибка в графе Количество минут на льду");
                                mus_flag = false;
                            }
                        }
                        catch (NullReferenceException)
                        {
                            MessageBox.Show("Ошибка в графе Количество минут на льду");
                            mus_flag = false;
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Ошибка в графе Количество минут на льду");
                            mus_flag = false;
                        }
                        break;
                }
            }
            bool flag2 = true;
            if (mus_flag)
            {

                string line = "";
                using (StreamReader file = new StreamReader("command.txt"))
                {
                    while ((line = file.ReadLine()) != null)
                    {
                        string[] str_arr = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        if (str_arr[0] + " " + str_arr[1] + " " + str_arr[2] == dataGridView2[0, 0].Value.ToString())
                        {

                            flag2 = false;
                            label2.Text = "Good";
                            MessageBox.Show("Данный игрок уже зарегистрирован");
                        }
                        label3.Text = str_arr[0] + " " + str_arr[1] + " " + str_arr[2];
                        label3.Text = dataGridView2[0, 0].Value.ToString();
                    }
                }
            }
            using (StreamWriter file = new StreamWriter("command.txt", true))
            {
                if (flag2)
                {

                    for (int i = 0; i < 9; i++)
                    {
                        file.Write(dataGridView2[i, 0].Value + " ");
                    }
                    file.WriteLine();
                    file.Close();
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView3.Rows.Clear();
            int index = listBox1.SelectedIndex;
            string line = "";
            using (StreamReader file = new StreamReader("command.txt"))
            {
                while ((line = file.ReadLine()) != null)
                {
                    string[] str_arr = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (str_arr.Length != 0)
                    {
                        command.full_name = str_arr[0] + " " + str_arr[1] + " " + str_arr[2];
                        command.role = str_arr[3];
                        command.height = str_arr[4];
                        command.weight = str_arr[5];
                        command.reference_year = str_arr[6];
                        command.number_goals_scored = str_arr[7];
                        command.penalty = str_arr[8];
                        command.number_deletions = str_arr[9];
                        command.number_minutes_field = str_arr[10];
                      
                    }
                    switch (index)
                    {
                        case 0:
                            if (textBox1.Text == command.full_name)
                            {

                                string[] row = new string[] { command.full_name, command.role, command.height, command.weight, command.reference_year, command.number_goals_scored, command.penalty, command.number_deletions, command.number_minutes_field };
                                dataGridView3.Rows.Add(row);
                            }
                            break;
                        case 1:
                            if (textBox1.Text == command.role)
                            {

                                string[] row = new string[] { command.full_name, command.role, command.height, command.weight, command.reference_year, command.number_goals_scored, command.penalty, command.number_deletions, command.number_minutes_field };
                                dataGridView3.Rows.Add(row);
                            }
                            break;
                        case 2:
                            if (textBox1.Text == command.height)
                            {

                                string[] row = new string[] { command.full_name, command.role, command.height, command.weight, command.reference_year, command.number_goals_scored, command.penalty, command.number_deletions, command.number_minutes_field };
                                dataGridView3.Rows.Add(row);
                            }
                            break;
                        case 3:
                            if (textBox1.Text == command.weight)
                            {

                                string[] row = new string[] { command.full_name, command.role, command.height, command.weight, command.reference_year, command.number_goals_scored, command.penalty, command.number_deletions, command.number_minutes_field };
                                dataGridView3.Rows.Add(row);
                            }
                            break;
                        case 4:
                            if (textBox1.Text == command.reference_year)
                            {

                                string[] row = new string[] { command.full_name, command.role, command.height, command.weight, command.reference_year, command.number_goals_scored, command.penalty, command.number_deletions, command.number_minutes_field };
                                dataGridView3.Rows.Add(row);
                            }
                            break;
                        case 5:
                            if (textBox1.Text == command.number_goals_scored)
                            {

                                string[] row = new string[] { command.full_name, command.role, command.height, command.weight, command.reference_year, command.number_goals_scored, command.penalty, command.number_deletions, command.number_minutes_field };
                                dataGridView3.Rows.Add(row);
                            }
                            break;
                        case 6:
                            if (textBox1.Text == command.penalty)
                            {

                                string[] row = new string[] { command.full_name, command.role, command.height, command.weight, command.reference_year, command.number_goals_scored, command.penalty, command.number_deletions, command.number_minutes_field };
                                dataGridView3.Rows.Add(row);
                            }
                            break;
                        case 7:
                            if (textBox1.Text == command.number_deletions)
                            {

                                string[] row = new string[] { command.full_name, command.role, command.height, command.weight, command.reference_year, command.number_goals_scored, command.penalty, command.number_deletions, command.number_minutes_field };
                                dataGridView3.Rows.Add(row);
                            }
                            break;
                        case 8:
                            if (textBox1.Text == command.number_minutes_field)
                            {

                                string[] row = new string[] { command.full_name, command.role, command.height, command.weight, command.reference_year, command.number_goals_scored, command.penalty, command.number_deletions, command.number_minutes_field };
                                dataGridView3.Rows.Add(row);
                            }
                            break;
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (StreamWriter file = new StreamWriter("command.txt"))
            {
                file.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (StreamWriter file2 = new StreamWriter("command2.txt"))
            {
                file2.Close();
            }
            bool flag = false;
            int index = listBox1.SelectedIndex;
            string line = "";
            using (StreamReader file = new StreamReader("command.txt"))
            {
                while ((line = file.ReadLine()) != null)
                {
                    flag = false;
                    string[] str_arr = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    command.full_name = str_arr[0] + " " + str_arr[1] + " " + str_arr[2];
                    command.role = str_arr[3];
                    command.height = str_arr[4];
                    command.weight = str_arr[5];
                    command.reference_year = str_arr[6];
                    command.number_goals_scored = str_arr[7];
                    command.penalty = str_arr[8];
                    command.number_deletions = str_arr[9];
                    command.number_minutes_field = str_arr[10];
                    switch (index)
                    {
                        case 0:
                            if (textBox1.Text == command.full_name)
                            {
                                flag = true;
                            }
                            break;
                        case 1:
                            if (textBox1.Text == command.role)
                            {
                                flag = true;
                            }
                            break;
                        case 2:
                            if (textBox1.Text == command.height)
                            {
                                flag = true; ;
                            }
                            break;
                        case 3:
                            if (textBox1.Text == command.weight)
                            {
                                flag = true;
                            }
                            break;
                        case 4:
                            if (textBox1.Text == command.reference_year)
                            {
                                flag = true;
                            }
                            break;
                        case 5:
                            if (textBox1.Text == command.number_goals_scored)
                            {
                                flag = true;
                            }
                            break;
                        case 6:
                            if (textBox1.Text == command.penalty)
                            {
                                flag = true;
                            }
                            break;
                        case 7:
                            if (textBox1.Text == command.number_deletions)
                            {
                                flag = true;
                            }
                            break;
                        case 8:
                            if (textBox1.Text == command.number_minutes_field)
                            {

                                flag = true;
                            }
                            break;
                    }
                    if (flag)
                    {

                    }
                    else
                    {
                        using (StreamWriter file2 = new StreamWriter("command2.txt", true))
                        {
                            file2.WriteLine(line);
                        }
                    }
                }

            }
            using (StreamReader file = new StreamReader("command2.txt"))
            {
                using (StreamWriter file2 = new StreamWriter("command.txt"))
                {
                    while ((line = file.ReadLine()) != null)
                    {
                        file2.WriteLine(line);
                    }
                    file.Close();

                }
                file.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            bool mus_flag = true;
            for (int j = 0; j < dataGridView4.Rows.Count; j++)
            {

                for (int i = 0; i < 9; i++)
                {
                    ///блок проверки на ошибки


                    switch (i)
                    {
                        case 0:
                            try
                            {
                                string line = dataGridView4[i, j].Value.ToString();
                                string[] str_arr = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                                bool flag = false;
                                for (int z = 0; z < line.Length; z++)
                                {
                                    flag = char.IsNumber(line[j]);
                                }
                                if ((str_arr.Length != 3) || (flag))
                                {
                                    MessageBox.Show("Ошибка в графе ФИО");
                                    mus_flag = false;
                                }
                            }
                            catch (NullReferenceException)
                            {

                                MessageBox.Show("Ошибка в графе ФИО");
                                mus_flag = false;
                            }

                            break;
                        case 1:
                            try
                            {

                                string line = dataGridView4[i, j].Value.ToString();
                                string[] str_arr = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                                bool flag = false;
                                for (int z = 0; z < line.Length; z++)
                                {
                                    flag = char.IsNumber(line[j]);
                                }
                                if ((flag) || ((line != "Вратарь") && (line != "Нападающий") && (line != "Защитник")))
                                {
                                    MessageBox.Show("Ошибка в графе Амплуа");
                                    mus_flag = false;
                                }
                            }
                            catch (NullReferenceException)
                            {

                                MessageBox.Show("Ошибка в графе Амплуа");
                                mus_flag = false;
                            }

                            break;
                        case 2:
                            try
                            {
                                int height = Convert.ToInt32(dataGridView4[i, j].Value);
                                if (height < 50 || height > 251)
                                {
                                    MessageBox.Show("Ошибка в графе Рост");
                                    mus_flag = false;
                                }
                            }
                            catch (NullReferenceException)
                            {
                                MessageBox.Show("Ошибка в графе Рост");
                                mus_flag = false;
                            }
                            catch (FormatException)
                            {
                                MessageBox.Show("Ошибка в графе Рост");
                                mus_flag = false;
                            }
                            break;
                        case 3:

                            try
                            {
                                int weight = Convert.ToInt32(dataGridView4[i, j].Value);
                                if (weight < 50 || weight > 150)
                                {
                                    MessageBox.Show("Ошибка в графе Вес");
                                    mus_flag = false;
                                }
                            }
                            catch (NullReferenceException)
                            {
                                MessageBox.Show("Ошибка в графе Вес");
                                mus_flag = false;
                            }
                            catch (FormatException)
                            {
                                MessageBox.Show("Ошибка в графе Вес");
                                mus_flag = false;
                            }


                            break;
                        case 4:
                            try
                            {
                                int year = Convert.ToInt32(dataGridView4[i, j].Value);
                                if (year < 0 || year > 2023)
                                {
                                    MessageBox.Show("Ошибка в графе Контрольный год");
                                    mus_flag = false;
                                }
                            }
                            catch (NullReferenceException)
                            {
                                MessageBox.Show("Ошибка в графе Контрольный год");
                                mus_flag = false;
                            }
                            catch (FormatException)
                            {
                                MessageBox.Show("Ошибка в графе Контрольный год");
                                mus_flag = false;
                            }

                            break;
                        case 5:
                            try
                            {
                                int goal = Convert.ToInt32(dataGridView4[i, j].Value);
                                if (goal < 0)
                                {
                                    MessageBox.Show("Ошибка в графе Количество забитых шайб");
                                    mus_flag = false;
                                }
                            }
                            catch (NullReferenceException)
                            {
                                MessageBox.Show("Ошибка в графе Количество забитых шайб");
                                mus_flag = false;
                            }
                            catch (FormatException)
                            {
                                MessageBox.Show("Ошибка в графе Количество забитых шайб");
                                mus_flag = false;
                            }

                            break;
                        case 6:
                            try
                            {
                                int penalty = Convert.ToInt32(dataGridView4[i, j].Value);
                                if (penalty < 0)
                                {
                                    MessageBox.Show("Ошибка в графе Штраф");
                                    mus_flag = false;
                                }
                            }
                            catch (NullReferenceException)
                            {
                                MessageBox.Show("Ошибка в графе Штраф");
                                mus_flag = false;
                            }
                            catch (FormatException)
                            {
                                MessageBox.Show("Ошибка в графе Штраф");
                                mus_flag = false;
                            }


                            break;
                        case 7:
                            try
                            {
                                int delet = Convert.ToInt32(dataGridView4[i, j].Value);
                                if (delet < 0)
                                {
                                    MessageBox.Show("Ошибка в графе Количество удалений");
                                    mus_flag = false;
                                }
                            }
                            catch (NullReferenceException)
                            {
                                MessageBox.Show("Ошибка в графе Количество удалений");
                                mus_flag = false;
                            }
                            catch (FormatException)
                            {
                                MessageBox.Show("Ошибка в графе Количество удалений");
                                mus_flag = false;
                            }
                            break;
                        case 8:
                            try
                            {
                                int field = Convert.ToInt32(dataGridView4[i, j].Value);
                                if (field < 0)
                                {
                                    MessageBox.Show("Ошибка в графе Количество минут на льду");
                                    mus_flag = false;
                                }
                            }
                            catch (NullReferenceException)
                            {
                                MessageBox.Show("Ошибка в графе Количество минут на льду");
                                mus_flag = false;
                            }
                            catch (FormatException)
                            {
                                MessageBox.Show("Ошибка в графе Количество минут на льду");
                                mus_flag = false;
                            }
                            break;
                    }
                    bool flag2 = true;

                }
                if (mus_flag)
                    using (StreamWriter file = new StreamWriter("command.txt"))
                    {


                        for (int i = 0; i < 9; i++)
                        {
                            file.Write(dataGridView4[i, j].Value + " ");
                        }
                        file.WriteLine();
                        file.Close();


                    }
            }
        }
    }
}

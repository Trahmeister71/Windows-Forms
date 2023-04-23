using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.IO;
using System.Threading;
using System.Xml.Serialization;
using System.Windows.Media;
using Color = System.Drawing.Color;
using Timer = System.Windows.Forms.Timer;

namespace Кто_хочет_стать_миллионером
{
    public partial class Form1 : Form
    {
        public List<Question> questions;
        int i = 0;
        int str = 14;
        Timer timer;
        public class Question
        {
            public string Text { get; set; }
            public string[] Answers { get; set; }
            public int CorrectAnswerIndex { get; set; }
            public int DifficultyLevel { get; set; }
            public int GetAnswer()
            {
                return CorrectAnswerIndex;
            }
        }


        public Form1()
        {
            InitializeComponent();
            timer = new Timer();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            SoundPlayer player = new SoundPlayer("zastavka.wav");
            player.Play();
            #region Перерисовка текста в ричедит
            richTextBox1.ReadOnly = false;
            richTextBox1.BackColor = Color.Black;
            richTextBox1.Select(richTextBox1.GetFirstCharIndexFromLine(0), richTextBox1.GetFirstCharIndexFromLine(1) - richTextBox1.GetFirstCharIndexFromLine(0));
            richTextBox1.SelectionColor = Color.Orange;

            richTextBox1.Select(richTextBox1.GetFirstCharIndexFromLine(5), richTextBox1.GetFirstCharIndexFromLine(6) - richTextBox1.GetFirstCharIndexFromLine(5));
            richTextBox1.SelectionColor = Color.Orange;

            richTextBox1.Select(richTextBox1.GetFirstCharIndexFromLine(10), richTextBox1.GetFirstCharIndexFromLine(11) - richTextBox1.GetFirstCharIndexFromLine(10));
            richTextBox1.SelectionColor = Color.Orange;

            richTextBox1.Select(richTextBox1.GetFirstCharIndexFromLine(14), richTextBox1.GetFirstCharIndexFromLine(14) - richTextBox1.GetFirstCharIndexFromLine(13));
            richTextBox1.SelectionBackColor = Color.DarkOrange;

            richTextBox1.SelectionStart = richTextBox1.GetFirstCharIndexFromLine(14) + richTextBox1.Lines.Length * 2;

            richTextBox2.SelectionAlignment = HorizontalAlignment.Center;
            #endregion
            questions = new List<Question>()
            {
                new Question
                {
                    Text = "Как называется главный герой романа Льва Толстого 'Война и мир'?",
                    Answers = new string[] { "Андрей Болконский", "Пьер Безухов", "Наташа Ростова", "Анна Каренина" },
                    CorrectAnswerIndex = 1,
                    DifficultyLevel = 1
                },
                new Question
                {
                    Text = "Какой элемент периодической таблицы химических элементов имеет символ 'C'?",
                    Answers = new string[] { "Кислород", "Углерод", "Кальций", "Калий" },
                    CorrectAnswerIndex = 1,
                    DifficultyLevel = 1
                },
                new Question
                {
                    Text = "Какое из этих животных не является насекомым?",
                    Answers = new string[] { "Комар", "Скорпион", "Жук", "Пчела" },
                    CorrectAnswerIndex = 1,
                    DifficultyLevel = 1
                },
                new Question
                {
                    Text = "Кто написал роман '1984'?",
                    Answers = new string[] { "Эрнест Хемингуэй", "Джон Стейнбек", "Джордж Оруэлл", "Рэй Брэдбери" },
                    CorrectAnswerIndex = 2,
                    DifficultyLevel = 1
                },
                new Question
                {
                    Text = "В каком году состоялось первое чемпионат мира по футболу?",
                    Answers = new string[] { "1930", "1950", "1970", "1990" },
                    CorrectAnswerIndex = 0,
                    DifficultyLevel = 2
                },
                new Question
                {
                    Text = "Как называется самая большая пустыня в мире?",
                    Answers = new string[] { "Сахара", "Атакама", "Гоби", "Антарктида" },
                    CorrectAnswerIndex = 3,
                    DifficultyLevel = 2
                },
                new Question
                {
                    Text = "Как называется самое большое озеро в мире?",
                    Answers = new string[] { "Байкал", "Виктория", "Гурон", "Мичиган" },
                    CorrectAnswerIndex = 0,
                    DifficultyLevel = 2
                },
                new Question
                {
                    Text = "Кто из этих художников не был представителем импрессионизма?",
                    Answers = new string[] { "Клод Моне", "Эдуард Мане", "Поль Сезанн", "Винсент Ван Гог" },
                    CorrectAnswerIndex = 3,
                    DifficultyLevel = 2
                },
                new Question
                {
                  Text = "Какое из этих произведений не является трагедией Шекспира?",
                  Answers = new string[] { "Ромео и Джульетта", "Гамлет", "Отелло", "Макбет" },
                   CorrectAnswerIndex = 0,
                     DifficultyLevel = 3
                },
                    new Question
                    {
                      Text = "Как называется язык программирования, созданный Ларри Уоллом и выпущенный в 1987 году?",
                      Answers = new string[] { "Java", "C++", "Perl", "Python" },
                         CorrectAnswerIndex = 2,
                        DifficultyLevel = 3
                    },
                    new Question
                    {
                        Text = "Какое событие вызвало начало Первой мировой войны?",
                        Answers = new string[] { "Убийство архидука Франц-Фердинанда", "Подписание Договора о ненападении между Германией и СССР", "Нападение Японии на США в Пёрл-Харборе", "Принятие Резолюции ООН о создании Израиля" },
                        CorrectAnswerIndex = 0,
                        DifficultyLevel = 3
                    },
                    new Question
                    {
                        Text = "Кто является автором романа 'Атлант расправил плечи'?",
                        Answers = new string[] { "Эйн Рэнд", "Оскар Уайльд", "Фрэнсис Скотт Фицджеральд", "Эрнест Хемингуэй" },
                        CorrectAnswerIndex = 0,
                        DifficultyLevel = 4
                    },
                    new Question
                    {
                        Text = "Какой физик сформулировал три закона механики?",
                        Answers = new string[] { "Исаак Ньютон", "Альберт Эйнштейн", "Макс Планк", "Нильс Бор" },
                        CorrectAnswerIndex = 0,
                        DifficultyLevel = 4
                    },
                    new Question
                    {
                        Text = "Какой химический элемент был назван в честь героя греческой мифологии?",
                        Answers = new string[] { "Торий", "Керий", "Прометий", "Икарий" },
                        CorrectAnswerIndex = 2,
                        DifficultyLevel = 5
                    },
                    new Question
                    {
                        Text = "Какой астрономический объект был открыт в 1930 году и потом был позже лишен своего статуса планеты?",
                        Answers = new string[] { "Уран", "Нептун", "Плутон", "Хаумеа" },
                        CorrectAnswerIndex = 2,
                        DifficultyLevel = 5
                    }
            };
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Question>));
            using (FileStream fileStream = new FileStream("questions.xml", FileMode.Create))
            {
                xmlSerializer.Serialize(fileStream, questions);
            }
            XmlSerializer xmlSerializer2 = new XmlSerializer(typeof(List<Question>));
            using (FileStream fileStream = new FileStream("questions.xml", FileMode.Open))
            {
                questions = (List<Question>)xmlSerializer2.Deserialize(fileStream);
            }
        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult rez = MessageBox.Show("Прекратить игру?", "Пауза", MessageBoxButtons.OKCancel);
            if (rez == DialogResult.OK)
            {
                SoundPlayer player = new SoundPlayer("nachallo.wav");
                player.Play();
                richTextBox2.Text = "";
                button2.Text = ""; button2.Enabled = false;
                button4.Text = ""; button3.Enabled = false;
                button3.Text = ""; button4.Enabled = false;
                button5.Text = ""; button5.Enabled = false;

            }

        }


        private void начатьИгруToolStripMenuItem_Click(object sender, EventArgs e)
        {
            i = 0;

            pictureBox2.Enabled = true;
            pictureBox2.Image = Image.FromFile("1.jpg");
            pictureBox3.Enabled = true;
            pictureBox3.Image = Image.FromFile("2.jpg");
            pictureBox4.Enabled = true;
            pictureBox4.Image = Image.FromFile("3.jpg");

            richTextBox2.Visible = true;
            button2.Visible = true;
            button4.Visible = true;
            button3.Visible = true;
            button5.Visible = true;
            button2.Enabled = true;
            button4.Enabled = true;
            button3.Enabled = true;
            button5.Enabled = true;

            SoundPlayer player = new SoundPlayer("nachallo.wav");
            player.Play();
            button5.Visible = true;
            richTextBox2.Text = questions[0].Text;
            button2.Text = questions[0].Answers[0];
            button4.Text = questions[0].Answers[1];
            button3.Text = questions[0].Answers[2];
            button5.Text = questions[0].Answers[3];

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int index = questions[i].GetAnswer();
            await Task.Run(() =>
                        {
                            if (str <= 1)
                            {
                                richTextBox1.Select(richTextBox1.GetFirstCharIndexFromLine(0), -(richTextBox1.GetFirstCharIndexFromLine(1) - richTextBox1.GetFirstCharIndexFromLine(0)));
                                richTextBox1.SelectionBackColor = Color.DarkOrange;
                                richTextBox1.Select(richTextBox1.GetFirstCharIndexFromLine(1), richTextBox1.GetFirstCharIndexFromLine(1) - richTextBox1.GetFirstCharIndexFromLine(0));
                                richTextBox1.SelectionBackColor = Color.Black;
                            }
                            else
                            {
                                richTextBox1.Select(richTextBox1.GetFirstCharIndexFromLine(str - 1), richTextBox1.GetFirstCharIndexFromLine(str - 1) - richTextBox1.GetFirstCharIndexFromLine(str - 2));
                                richTextBox1.SelectionBackColor = Color.DarkOrange;
                                richTextBox1.Select(richTextBox1.GetFirstCharIndexFromLine(str), richTextBox1.GetFirstCharIndexFromLine(str) - richTextBox1.GetFirstCharIndexFromLine(str - 1));
                                richTextBox1.SelectionBackColor = Color.Black;
                            }
                            richTextBox1.DeselectAll();
                        });
            #region Принимаем ответ
            if (button.Text == questions[i].Answers[index])
            {
                button.BackColor = Color.Green;
                button2.Enabled = false;
                button4.Enabled = false;
                button3.Enabled = false;
                button5.Enabled = false;
                button.Enabled = true;
                await Task.Run(() =>
                {
                    SoundPlayer player = new SoundPlayer("correct.wav");
                    player.Play();
                    Thread.Sleep(5000);
                });
                str--;
                if (str == -1)
                {
                    SoundPlayer end = new SoundPlayer("end.wav");
                    end.Play();
                    DialogResult en = MessageBox.Show("Вы выиграли 1 000 000 гривен", "Конец игры", MessageBoxButtons.OK);
                    if (en == DialogResult.OK)
                    {
                        Application.Exit();
                    }
                }
                else if(str == 10 || str ==5)
                {
                    DialogResult rez= MessageBox.Show("Забрать выигрышь?","Выигрышь",MessageBoxButtons.YesNo);
                    if(rez == DialogResult.OK)
                    {
                        SoundPlayer end = new SoundPlayer("end.wav");
                        end.Play();
                        if (str == 10)
                        {
                            
                            MessageBox.Show("Вы выиграли 5 000 гривен");
                        }
                        else
                        {
                            
                            MessageBox.Show("Вы выиграли 10 000 гривен");
                        }

                    }
                }
            }
            else
            {
                button.BackColor = Color.Red;
                button2.Enabled = false; button3.Enabled = false; button4.Enabled = false; button5.Enabled = false;
                button.Enabled = true;
                await Task.Run(() =>
                {
                    SoundPlayer player = new SoundPlayer("nevernyi.wav");
                    player.Play();
                    Thread.Sleep(5000);
                    DialogResult rez = MessageBox.Show("Вы проиграли\nПопробовать еще раз?", "Конец игры", MessageBoxButtons.RetryCancel);
                    if (rez == DialogResult.Retry)
                    {
                        Application.Restart();
                    }
                    else
                    {
                        Application.Exit();
                    }

                });
            }
            #endregion
            #region Перерисовка вопроса
            i++;
            button2.Enabled = true;
            button4.Enabled = true;
            button3.Enabled = true;
            button5.Enabled = true;
            button.BackColor = Color.Black;
            richTextBox2.Text = questions[i].Text;
            button2.Text = questions[i].Answers[0];
            button4.Text = questions[i].Answers[1];
            button3.Text = questions[i].Answers[2];
            button5.Text = questions[i].Answers[3];
            #endregion
            #region Музыка выбора ответа
            if (new Random().Next(1, 3) == 1)
            {
                SoundPlayer soundPlayer = new SoundPlayer("tik.wav");
                soundPlayer.Play();
            }
            else if (new Random().Next(1, 3) == 2)
            {
                SoundPlayer soundPlayer = new SoundPlayer("voln.wav");
                soundPlayer.Play();
            }
            #endregion
        }

        private async void pictureBox2_Click(object sender, EventArgs e)
        {

            int index = questions[i].GetAnswer();
            int ch = new Random().Next(0, 4);
            int temp = ch;
            for (int j = 0; j < 2;)
            {

                switch (ch)
                {
                    case 0:
                        if (button2.Text != questions[i].Answers[index])
                        {
                            await Task.Run(() => {
                                button2.BeginInvoke(new Action(() => {
                                    button2.Text = "";
                                }));
                            });
                        }
                        break;
                    case 1:
                        if (button3.Text != questions[i].Answers[index])
                        {
                            await Task.Run(() => {
                                button3.BeginInvoke(new Action(() => {
                                    button3.Text = "";
                                }));
                            });
                        }
                        break;
                    case 2:
                        if (button4.Text != questions[i].Answers[index])
                        {
                            await Task.Run(() => {
                                button4.BeginInvoke(new Action(() => {
                                    button4.Text = "";
                                }));
                            });
                        }
                        break;
                    case 3:
                        if (button5.Text != questions[i].Answers[index])
                        {
                            await Task.Run(() => {
                                button5.BeginInvoke(new Action(() => {
                                    button5.Text = "";
                                }));
                            });
                        }
                        break;
                }
                while (true)
                {
                    ch = new Random().Next(0, 4);
                    if (ch != temp)
                    {
                        j++;
                        break;
                    }
                }
            }
            await Task.Run(() =>
            {
                pictureBox2.Image = Image.FromFile("4.jpg");
                pictureBox2.Enabled = false;
            });
        }
        int indexans;
        private  void pictureBox3_Click(object sender, EventArgs e)
        {
            indexans = questions[i].CorrectAnswerIndex;
            SoundPlayer player = new SoundPlayer("zvonok.wav");
            player.Play();

            timer.Interval = 5000; 
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();

            pictureBox3.Enabled = false;
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            pictureBox7.Visible = true;
            textBox1.Visible = true;
            textBox1.Text = "Я думаю это ответ номер " + (indexans + 1);

            timer.Interval = 5000; 
            timer.Tick -= new EventHandler(timer_Tick);
            timer.Tick += new EventHandler(timer_Tick2);
        }

        private void timer_Tick2(object sender, EventArgs e)
        {
            pictureBox7.Visible = false;
            textBox1.Visible = false;
            pictureBox3.Image = Image.FromFile("5.jpg");

            timer.Tick -= new EventHandler(timer_Tick2);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            int index = questions[i].CorrectAnswerIndex;
            groupBox2.Visible = true;
            if(index == 0)
            {
                label5.Text = "41%";
                label6.Text = "19%";
                label7.Text = "15%";
                label8.Text = "25%";
            }
            else if(index == 1)
            {
                label5.Text = "12%";
                label6.Text = "51%";
                label7.Text = "14%";
                label8.Text = "13%";
            }
            else if (index == 2)
            {
                label5.Text = "18%";
                label6.Text = "24%";
                label7.Text = "38%";
                label8.Text = "20%";
            }
            else if (index == 3)
            {
                label5.Text = "24%";
                label6.Text = "19%";
                label7.Text = "15%";
                label8.Text = "42%";
            }
            timer1.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            pictureBox4.Image = Image.FromFile("6.jpg");
            timer1.Stop();
        }
    }
        
    
}

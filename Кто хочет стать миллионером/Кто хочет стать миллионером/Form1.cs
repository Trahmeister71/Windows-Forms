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
        
        public static List<Question> questions;
        int i = 0;
        int str = 14;
        int level = 1;
        Timer timer;
        public Question quest;
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
            public static Question Rand(int diff)
            {
                while (true)
                {
                    int rez = new Random().Next(0, questions.Count);
                    if (questions[rez].DifficultyLevel == diff)
                        return questions[rez];
                }
                

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
                    Text = "Как называется столица Франции?",
                    Answers = new string[] { "Мадрид", "Лондон", "Париж", "Рим" },
                    CorrectAnswerIndex = 2,
                    DifficultyLevel = 1
                },
                new Question
                {
                    Text = "Кто является автором романа 'Гарри Поттер и философский камень'?",
                    Answers = new string[] { "Дж. Р. Р. Толкин", "Джордж Р. Р. Мартин", "Джоан Роулинг", "Джон Рональд Руэл Толкин" },
                    CorrectAnswerIndex = 2,
                    DifficultyLevel = 1
                },
                new Question
                {
                    Text = "Как называется самая большая пустыня в мире?",
                    Answers = new string[] { "Гоби", "Каракумы", "Атакама", "Сахара" },
                    CorrectAnswerIndex = 3,
                    DifficultyLevel = 1
                },
                new Question
                {
                    Text = "Какое море является самым большим в мире?",
                    Answers = new string[] { "Красное море", "Аравийское море", "Средиземное море", "Тихий океан" },
                    CorrectAnswerIndex = 3,
                    DifficultyLevel = 1
                },
                new Question
                {
                    Text = "Как называется столица Италии?",
                    Answers = new string[] { "Мадрид", "Лондон", "Париж", "Рим" },
                    CorrectAnswerIndex = 3,
                    DifficultyLevel = 1
                },
                new Question
                {
                    Text = "Как называется собака в мультфильме 'Том и Джерри'?",
                    Answers = new string[] { "Спайк", "Барбос", "Шарик", "Рекс" },
                    CorrectAnswerIndex = 0,
                    DifficultyLevel = 1
                },
                new Question
                {
                    Text = "Кто является автором романа 'Поднятая целина'?",
                    Answers = new string[] { "Федор Достоевский", "Лев Толстой", "Михаил Лермонтов", "Михаил Шолохов" },
                    CorrectAnswerIndex = 3,
                    DifficultyLevel = 1
                },
                new Question
                {
                    Text = "Какое животное является символом компании Twitter?",
                    Answers = new string[] { "Синица", "Ласточка", "Сорока", "Голубь" },
                    CorrectAnswerIndex = 3,
                    DifficultyLevel = 1
                },
                new Question
                {
                    Text = "Как называется процесс, при котором светильник начинает мерцать при увеличении тока?",
                    Answers = new string[] { "Фотоэффект", "Гальваномагнитный эффект", "Эффект Джоуля", "Электролюминесценция" },
                    CorrectAnswerIndex = 3,
                    DifficultyLevel = 2
                },
                new Question
                {
                    Text = "Какое из следующих чисел является простым: 87, 97, 107, 117?",
                    Answers = new string[] { "87", "97", "107", "117" },
                    CorrectAnswerIndex = 1,
                    DifficultyLevel = 2
                },
                new Question
                {
                    Text = "Какое языковое семейство относится к языку греческий?",
                    Answers = new string[] { "Германское", "Индоевропейское", "Финно-угорское", "Славянское" },
                    CorrectAnswerIndex = 1,
                    DifficultyLevel = 2
                },
                new Question
                {
                    Text = "Как называется язык программирования, разработанный Google?",
                    Answers = new string[] { "Java", "Python", "Ruby", "Go" },
                    CorrectAnswerIndex = 3,
                    DifficultyLevel = 2
                },
                new Question
                {
                    Text = "Как называется наука, которая изучает жизненные процессы в организмах?",
                    Answers = new string[] { "Геология", "Ботаника", "Физика", "Биология" },
                    CorrectAnswerIndex = 3,
                    DifficultyLevel = 2
                },
                new Question
                {
                    Text = "Какое из следующих выражений является антонимом слова 'безупречный':",
                    Answers = new string[] { "Совершенный", "Несовершенный", "Отличный", "Превосходный" },
                    CorrectAnswerIndex = 1,
                    DifficultyLevel = 2
                },
                new Question
                {
                    Text = "Как называется наибольший сплав золота?",
                    Answers = new string[] { "Карат", "Платина", "Органическое стекло", "Бронза" },
                    CorrectAnswerIndex = 0,
                    DifficultyLevel = 2
                },
                new Question
                {
                    Text = "Какой год был принят как начало новой эры в западной историографии?",
                    Answers = new string[] { "1 год до нашей эры", "1 год нашей эры", "476 год нашей эры", "800 год нашей эры" },
                    CorrectAnswerIndex = 1,
                    DifficultyLevel = 2
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
                    Text = "Кто из перечисленных является основателем теории общественного договора?",
                    Answers = new string[] { "Рене Декарт", "Джон Локк", "Джон Стюарт Милль", "Иммануил Кант" },
                    CorrectAnswerIndex = 1,
                    DifficultyLevel = 3
                },
                new Question
                {
                    Text = "Как называется теория, которая гласит, что все существующее можно разложить на более мелкие компоненты?",
                    Answers = new string[] { "Теория относительности", "Квантовая механика", "Теория эволюции", "Атомизм" },
                    CorrectAnswerIndex = 3,
                    DifficultyLevel = 3
                },
                new Question
                {
                    Text = "Какое из следующих искусств является наиболее старым?",
                    Answers = new string[] { "Литература", "Архитектура", "Музыка", "Живопись" },
                    CorrectAnswerIndex = 0,
                    DifficultyLevel = 3
                },
                new Question
                {
                    Text = "Какое из следующих устройств можно использовать для получения информации о скорости автомобиля?",
                    Answers = new string[] { "Барометр", "Термометр", "Гидрометр", "Спидометр" },
                    CorrectAnswerIndex = 3,
                    DifficultyLevel = 3
                },
                new Question
                {
                    Text = "Какая из следующих планет является самой большой по диаметру?",
                    Answers = new string[] { "Венера", "Марс", "Юпитер", "Уран" },
                    CorrectAnswerIndex = 2,
                    DifficultyLevel = 3
                },
                new Question
                {
                    Text = "Как называется четвертое измерение в геометрии?",
                    Answers = new string[] { "Ширина", "Длина", "Высота", "Время" },
                    CorrectAnswerIndex = 3,
                    DifficultyLevel = 3
                },
                new Question
                {
                    Text = "Какой химический элемент был назван в честь великого открытия?",
                    Answers = new string[] { "Америций", "Кюрий", "Эйнштейний", "Менделевий" },
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
                    Text = "Как называется известная философская концепция, утверждающая, что каждый язык описывает мир по-своему?",
                    Answers = new string[] { "Деконструктивизм", "Лингвистический поворот", "Логический позитивизм", "Философия языка" },
                    CorrectAnswerIndex = 3,
                    DifficultyLevel = 4
                },
                new Question
                {
                    Text = "Как называется метод, который используется для вычисления предельных значений функций?",
                    Answers = new string[] { "Метод дифференциальных уравнений", "Метод вариационных принципов", "Метод конечных элементов", "Метод интегральных сумм" },
                    CorrectAnswerIndex = 2,
                    DifficultyLevel = 4
                },
                new Question
                {
                    Text = "Как называется печенье, которое используется в качестве идентификатора пользователя на сайтах?",
                    Answers = new string[] { "Файлы cookies", "Файлы XML", "Серверные сеансы", "Пользовательские агенты" },
                    CorrectAnswerIndex = 0,
                    DifficultyLevel = 4
                },
                new Question
                {
                    Text = "Как называется уравнение, которое описывает распространение тепла в твёрдом теле?",
                    Answers = new string[] { "Уравнение теплопроводности", "Уравнение Навье-Стокса", "Уравнение Максвелла", "Уравнение Шредингера" },
                    CorrectAnswerIndex = 0,
                    DifficultyLevel = 4
                },
                new Question
                {
                    Text = "Как называется феномен, при котором электромагнитные волны с большой длиной проникают в здания и препятствия?",
                    Answers = new string[] { "Дифракция", "Интерференция", "Рассеяние", "Преломление" },
                    CorrectAnswerIndex = 0,
                    DifficultyLevel = 4
                },
                new Question
                {
                    Text = "Как называется дисциплина, которая занимается исследованием структуры и свойств материалов на микро- и наноуровнях?",
                    Answers = new string[] { "Нанотехнологии", "Микроэлектроника", "Микромеханика", "Наноматериаловедение" },
                    CorrectAnswerIndex = 3,
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
                    Text = "Как называется явление, при котором измерение одной физической величины влияет на результат измерения другой величины?",
                    Answers = new string[] { "Эффект Холла", "Эффект Комптона", "Эффект Зеемана", "Эффект Гейзенберга" },
                    CorrectAnswerIndex = 3,
                    DifficultyLevel = 5
                },
                new Question
                {
                    Text = "Как называется теория, которая утверждает, что наша Вселенная расширяется со временем?",
                    Answers = new string[] { "Теория относительности", "Теория квантовых полей", "Теория большого взрыва", "Стринг-теория" },
                    CorrectAnswerIndex = 2,
                    DifficultyLevel = 5
                },
                new Question
                {
                    Text = "Как называется проблема, которая заключается в том, что вычисление значений функции требует экспоненциального времени в зависимости от размера входных данных?",
                    Answers = new string[] { "Проблема достижимости", "Проблема P vs NP", "Проблема оптимизации", "Проблема классификации" },
                    CorrectAnswerIndex = 1,
                    DifficultyLevel = 5
                },
                new Question
                {
                    Text = "Как называется теория, которая описывает, как элементарные частицы взаимодействуют между собой?",
                    Answers = new string[] { "Теория гравитации", "Теория электромагнитного взаимодействия", "Теория сильного взаимодействия", "Теория слабого взаимодействия" },
                    CorrectAnswerIndex = 3,
                    DifficultyLevel = 5
                },
                new Question
                {
                    Text = "Как называется теория, которая утверждает, что каждый компьютерный алгоритм можно перевести на набор инструкций машины Тьюринга?",
                    Answers = new string[] { "Теория алгоритмов", "Теория сложности вычислений", "Теория вычислимости", "Теория информации" },
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
            #region Сериализация
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
            #endregion

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
            quest = Question.Rand(level);
            richTextBox2.Text = quest.Text;
            button2.Text = quest.Answers[0];
            button4.Text = quest.Answers[1];
            button3.Text = quest.Answers[2];
            button5.Text = quest.Answers[3];
            questions.Remove(quest);
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int index = quest.GetAnswer();

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

            #region Принимаем ответ
            if (button.Text == quest.Answers[index])
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
                else if (str == 10 || str == 5)
                {
                    DialogResult rez = MessageBox.Show("Забрать выигрышь?", "Выигрышь", MessageBoxButtons.YesNo);
                    if (rez == DialogResult.Yes)
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
                        Application.Exit();
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
            if (i == 3 || i == 6 || i == 9 || i == 12 )
            { level++; }
            button2.Enabled = true;
            button4.Enabled = true;
            button3.Enabled = true;
            button5.Enabled = true;
            button.BackColor = Color.Black;
            quest = Question.Rand(level);
            richTextBox2.Text = quest.Text;
            button2.Text = quest.Answers[0];
            button4.Text = quest.Answers[1];
            button3.Text = quest.Answers[2];
            button5.Text = quest.Answers[3];
            questions.Remove(quest);
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            int index = quest.GetAnswer();
            int ch = new Random().Next(0, 4);
            int count = 0;
            for (; count < 2;)
            {
                int temp = ch;

                switch (ch)
                {
                    case 0:
                        if (button2.Text != quest.Answers[index])
                        {

                            button2.Invoke(new Action(() =>
                            {
                                button2.Text = "";
                            }));
                            count++;
                        }
                        break;
                    case 1:
                        if (button3.Text != quest.Answers[index])
                        {

                            button3.Invoke(new Action(() =>
                            {
                                button3.Text = "";
                            }));
                            count++;
                        }
                        break;
                    case 2:
                        if (button4.Text != quest.Answers[index])
                        {

                            button4.Invoke(new Action(() =>
                            {
                                button4.Text = "";
                            }));
                            count++;
                        }
                        break;
                    case 3:
                        if (button5.Text != quest.Answers[index])
                        {

                            button5.Invoke(new Action(() =>
                            {
                                button5.Text = "";
                            }));
                            count++;
                        }

                        break;
                }
                while (true)
                {
                    ch = new Random().Next(0, 4);
                    if (ch != temp)
                    {
                        break;
                    }

                }
            }


            pictureBox2.Image = Image.FromFile("4.jpg");
            pictureBox2.Enabled = false;

        }
        int indexans;
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            indexans = quest.CorrectAnswerIndex;
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
            int index = quest.CorrectAnswerIndex;
            groupBox2.Visible = true;
            if (index == 0)
            {
                label5.Text = "41%";
                label6.Text = "19%";
                label7.Text = "15%";
                label8.Text = "25%";
            }
            else if (index == 1)
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

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Игра \"Кто хочет стать миллионером\""+
                "\nПравила игры:\nОтвечать на интеллектуальные вопросы, за которые можно получить вознаграждение" +
                "\nВ игре присутстуют подсказки," +
                " которые могут облечать задачу(каждую подсказку можно использоваьб всего 1 раз)"+
                "\nНаписанна разработчиком Lichkun N.V", 
                "Как стать миллионером", MessageBoxButtons.OK);
        }
    }


}

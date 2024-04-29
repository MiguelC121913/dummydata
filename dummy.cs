using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace GeneradorDummyData
{
    public partial class MainForm : Form
    {
        private readonly string[] apellidosRuso = { "Смирнов", "Іванов", "Кузнєцов", "Попов", "Васильєв", "Петров", "Соколов", "Михайлов", "Новиков", "Федоров", "Морозов", "Волков", "Алексєєв", "Лєбєдь", "Семєнов", "Егоров", "Павлов", "Козлов", "Стєпанов", "Ніколаєв", "Орлов", "Андрєєв", "Макаров", "Нікітін", "Захаров", "Зайцев", "Соловйов", "Бєлов", "Медведєв", "Яковлєв", "Галкін", "Романов", "Воробйов", "Кошелєв", "Сєргєєв", "Павлюченко", "Сорокін", "Дмитрієв", "Григорьєв", "Ткач", "Костюк", "Королєв", "Гусєв", "Титов", "Кузьмін", "Кудрявцєв", "Баранов", "Кулик", "Артемов", "Щербак", "Панов", "Беляєв", "Комаров", "Денисов", "Казаков", "Фролов", "Жуков", "Горбачов", "Фомін", "Дорофєєв", "Бєліков", "Бєлоусов", "Потапов", "Лихачов", "Тимофєєв", "Федосєєв", "Шишкін", "Шевченко", "Родін", "Єрмаков", "Дмитрієв", "Данилов", "Козак", "Михайлов", "Герасимов", "Мартинов", "Єршов", "Горшков", "Сидоров", "Рязанов", "Ємельянов", "Рябов", "Анісімов", "Кузьмін", "Корнєєв", "Ефімов", "Дьячков", "Кулаков", "Лаптєв", "Шилов", "Бородін", "Закіров", "Давидов", "Голубєв", "Антонов", "Тарасов", "Бєров", "Полєв", "Марков", "Ісаєв", "Потьомкін", "Самсонов", "Князєв", "Бєсєдін" };
        private readonly string[] apellidosEspanol = { "García", "Fernández", "González", "Rodríguez", "López", "Martínez", "Sánchez", "Pérez", "Gómez", "Martín", "Jiménez", "Ruiz", "Hernández", "Díaz", "Moreno", "Muñoz", "Alonso", "Gutiérrez", "Romero", "Navarro", "Torres", "Domínguez", "Vargas", "Gil", "Ramos", "Serrano", "Blanco", "Molina", "Morales", "Suárez", "Ortega", "Delgado", "Castro", "Ortiz", "Rubio", "Marín", "Sanz", "Iglesias", "Medina", "Garrido", "Cortés", "Castillo", "Santos", "Lozano", "Guerrero", "Cano", "Prieto", "Méndez", "Cruz", "Gallego", "Vidal", "León", "Herrera", "Peña", "Flores", "Cabrera", "Campos", "Vega", "Fuentes", "Carrasco", "Diez", "Caballero", "Reyes", "Nieto", "Aguilar", "Pascual", "Santana", "Herrero", "Lorenzo", "Montero", "Hidalgo", "Giménez", "Ibáñez", "Ferrer", "Duran", "Santiago", "Vicente", "Benítez", "Mora", "Arias", "Vargas", "Carmona", "Crespo", "Román", "Pastor", "Soto", "Sáez", "Velasco", "Moya", "Soler", "Parra", "Esteban", "Bravo", "Gallardo", "Rojas" };
        private readonly string[] apellidosChino = { "Li", "Wang", "Zhang", "Liu", "Chen", "Yang", "Huang", "Zhao", "Wu", "Zhou", "Xu", "Sun", "Ma", "Zhu", "Hu", "Guo", "He", "Lin", "Gao", "Luo", "Zheng", "Song", "Han", "Tang", "Feng", "Yu", "Dong", "Xiao", "Cheng", "Cao", "Yuan", "Deng", "Wei", "Jiang", "Fu", "Bian", "Xie", "Shen", "Ye", "Xu", "Zeng", "Cai", "Peng", "Chang", "Pan", "Qi", "Lu", "Xiang", "Cui", "Wang", "Pei", "Fan", "Hong", "Zou", "Li", "He", "Liu", "Wei", "Jing", "Jian", "Hui", "Shi", "Yan", "Jia", "Tian", "Jiang", "Qi", "Shao", "Yi", "Chao", "Jun", "Gong", "Yao", "Jin", "Yi", "Yan", "Tong", "Yao", "Lan", "Yuan", "Bo", "Xia", "Jin", "Xiong", "Li", "Li", "Li", "Li", "Li", "Li", "Li", "Li", "Li", "Li" };
        private readonly Random random = new Random();

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            int cantidadRegistros = (int)nudCantidadRegistros.Value;
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < cantidadRegistros; i++)
            {
                sb.AppendLine(GenerarRegistro());
            }

            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "datos.txt");
            File.WriteAllText(filePath, sb.ToString());

            MessageBox.Show($"Se han generado {cantidadRegistros} registros y se han guardado en {filePath}", "Generación completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private string GenerarRegistro()
        {
            string nombre = GenerarNombreAleatorio();
            string apellido = GenerarApellidoAleatorio();
            int edad = random.Next(18, 101);

            return $"{nombre} {apellido}, {edad} años";
        }

        private string GenerarNombreAleatorio()
        {
            List<string> nombres = new List<string> { "Juan", "María", "Pedro", "Ana", "Luis", "Carmen", "Javier", "Elena", "José", "Laura", "Antonio", "Isabel", "Carlos", "Marta", "Miguel", "Lucía", "Francisco", "Raquel", "David", "Sara" };
            return nombres[random.Next(nombres.Count)];
        }

        private string GenerarApellidoAleatorio()
        {
            string[] listaApellidos;
            switch (cbxIdioma.SelectedIndex)
            {
                case 0:
                    listaApellidos = apellidosEspanol;
                    break;
                case 1:
                    listaApellidos = apellidosRuso;
                    break;
                case 2:
                    listaApellidos = apellidosChino;
                    break;
                default:
                    listaApellidos = apellidosEspanol;
                    break;
            }

            return listaApellidos[random.Next(listaApellidos.Length)];
         private void GuardarDatos(List<Persona> personas)
        {
            GuardarCSV(personas);
            GuardarXML(personas);
            GuardarJSON(personas);
        }

        private void GuardarCSV(List<Persona> personas)
        {
            StringBuilder csv = new StringBuilder();
            csv.AppendLine("Nombre,Apellido,Edad");

            foreach (var persona in personas)
            {
                csv.AppendLine($"{persona.Nombre},{persona.Apellido},{persona.Edad}");
            }

            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "datos.csv");
            File.WriteAllText(filePath, csv.ToString());
        }

        private void GuardarXML(List<Persona> personas)
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlElement root = xmlDoc.CreateElement("Personas");
            xmlDoc.AppendChild(root);

            foreach (var persona in personas)
            {
                XmlElement personaElement = xmlDoc.CreateElement("Persona");

                XmlElement nombreElement = xmlDoc.CreateElement("Nombre");
                nombreElement.InnerText = persona.Nombre;
                personaElement.AppendChild(nombreElement);

                XmlElement apellidoElement = xmlDoc.CreateElement("Apellido");
                apellidoElement.InnerText = persona.Apellido;
                personaElement.AppendChild(apellidoElement);

                XmlElement edadElement = xmlDoc.CreateElement("Edad");
                edadElement.InnerText = persona.Edad.ToString();
                personaElement.AppendChild(edadElement);

                root.AppendChild(personaElement);
            }

            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "datos.xml");
            xmlDoc.Save(filePath);
        }

        private void GuardarJSON(List<Persona> personas)
        {
            string json = JsonConvert.SerializeObject(personas, Formatting.Indented);
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "datos.json");
            File.WriteAllText(filePath, json);
        }
    }

    public class Persona
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
    }
}
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2
{
    public partial class Form1 : Form
    {
        List<Clientes>clientes = new List<Clientes>();
        List<DatosVe>datosVentas = new List<DatosVe>();
        int r1 = 0, v1 = 0, r2 = 0, v2 = 2, a1 = 0, a2 = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            agregar1();
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lista();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        public Form1()
        {
            InitializeComponent();
            cargar();
        }

        void guarCli()
        {
            StreamWriter guar = new StreamWriter(@"clientes.txt", true);

            try
            {
                guar.WriteLine(textBox6.Text);
                guar.WriteLine(textBox7.Text);
                guar.WriteLine(textBox8.Text);
            }
            catch
            {
                MessageBox.Show("Error!!!");
            }
            guar.Close();
        }

        void guarVe()
        {
            StreamWriter guar = new StreamWriter(@"datosVe.txt", true);

            try
            {
                guar.WriteLine(textBox1.Text);
                guar.WriteLine(textBox2.Text);
                guar.WriteLine(textBox3.Text);
                guar.WriteLine(textBox4.Text);
                guar.WriteLine(textBox5.Text);
            }
            catch
            {
                MessageBox.Show("Error!!!");
            }
            guar.Close();
        }

        private void agregar1()
        {
            guarCli();
            FileStream stream1 = new FileStream("clientes.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader1 = new StreamReader(stream1);

            while (reader1.Peek() > -1)
            {
                Clientes cliente = new Clientes();
                cliente.Nit = Convert.ToInt32(reader1.ReadLine());
                cliente.Nombre = reader1.ReadLine();
                cliente.Direccion = reader1.ReadLine();
                r1++;
                if (r1 == v1)
                {
                    clientes.Add(cliente);
                    v1++;
                    r1 = 0;

                }
            }

            reader1.Close();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = clientes;
            dataGridView1.Refresh();
        }

        private void agregar2()
        {
            guarVe();
            FileStream stream1 = new FileStream("datosVe.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader1 = new StreamReader(stream1);

            while (reader1.Peek() > -1)
            {
                DatosVe datos = new DatosVe();
                datos.Placa = reader1.ReadLine();
                datos.Marca = reader1.ReadLine();
                datos.Modelo = reader1.ReadLine();
                datos.Color = reader1.ReadLine();
                datos.Prekil = Convert.ToInt32(reader1.ReadLine());
                r2++;
                if (r2 == v2)
                {
                    datosVentas.Add(datos);
                    v2++;
                    r2 = 0;

                }
            }

            reader1.Close();

            dataGridView2.DataSource = null;
            dataGridView2.DataSource = datosVentas;
            dataGridView2.Refresh();
        }

        void lista()
        {
            string placa = textBox1.Text;
            int veces = 0;

            for (int i = 0; i < datosVentas.Count; i++)
            {
                if (placa == datosVentas[i].Placa)
                    veces++;
            }

            if (veces != 0)
            {
                MessageBox.Show("Ya esta repetido, intente nuevamente");
            }

            if(veces == 0)
            {
                agregar2();
                veces = 0;
            }
        }

        void cargar()
        {
            FileStream stream1 = new FileStream("clientes.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader1 = new StreamReader(stream1);
            while (reader1.Peek() > -1)
            {
                Clientes cliente = new Clientes();
                cliente.Nit = Convert.ToInt32(reader1.ReadLine());
                cliente.Nombre = reader1.ReadLine();
                cliente.Direccion = reader1.ReadLine();
               
                    clientes.Add(cliente);
                a1++;
            }
            reader1.Close();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = clientes;
            dataGridView1.Refresh();

            FileStream stream2 = new FileStream("datosVe.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader2 = new StreamReader(stream2);

            while (reader2.Peek() > -1)
            {
                DatosVe datos = new DatosVe();
                datos.Placa = reader2.ReadLine();
                datos.Marca = reader2.ReadLine();
                datos.Modelo = reader2.ReadLine();
                datos.Color = reader2.ReadLine();
                datos.Prekil = Convert.ToInt32(reader2.ReadLine());
                
                datosVentas.Add(datos);
                a2++;   
            }
            reader2.Close();

            dataGridView2.DataSource = null;
            dataGridView2.DataSource = datosVentas;
            dataGridView2.Refresh();
            v1 = a1 + 1;
            v2 = a2 + 1;
        }

        void calc()
        {

        }
    }
}

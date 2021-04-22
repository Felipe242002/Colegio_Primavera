using Colegio_Primavera.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Colegio_Primavera
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

 
        private void Form1_Load(object sender, EventArgs e)
        {
            ContextBD bd = new ContextBD();
            ComboCursos.DataSource = bd.Cursos.ToList();
            ComboCursos.DisplayMember = "Nombre";


        }

        private void comboCursos_SelectedIndexChanged(object sender, EventArgs e)
        {
            ContextBD bd = new ContextBD();

            Cursos CursoSeleccionado = (Cursos)ComboCursos.SelectedItem;
            txtProfesor.Text = CursoSeleccionado.Profesores.Nombre;
            List<Alumnos> AlumnosDelCurso = bd.Alumnos.Where(Alumnos => Alumnos.idCurso == CursoSeleccionado.idCurso).ToList();
            gridAlumnos.DataSource = AlumnosDelCurso;
            gridAlumnos.Columns[0].Visible = false;
            gridAlumnos.Columns[3].Visible = false;
            gridAlumnos.Columns[4].Visible = false;


        }

        private void txtProfesor_TextChanged(object sender, EventArgs e)
        {
            

        }
    }
}

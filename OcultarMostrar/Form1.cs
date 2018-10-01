using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace OcultarMostrar
{
    public partial class Form1 : Form
    {
        //Constantes para ShowWindow  
        private const int SW_HIDE = 0;
        private const int SW_NORMAL = 1;

       //Busca el handle de una ventana hija a partir de su Hwnd Parent y el nombre de clase
        [DllImport("user32")]
        private static extern IntPtr FindWindowEx(IntPtr hWnd1, int hWnd2, string lpsz1, string lpsz2); 

       //Busca el HWND de la ventana, en este caso la de la barra de tareas de windows ( mediante el nombre de clase Shell_TrayWnd )  
        [DllImport("user32")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName); 

        //Oculta y muestra una ventana a partir de su HWND  
        [DllImport("user32")]
        private static extern void ShowWindow(IntPtr hwnd, int nCmdShow);

        private IntPtr HWND_TaskBar;
        private IntPtr HWND_TrayNotify;
        private IntPtr HWND_Iconos;
        private IntPtr HWND_Reloj;
        private IntPtr HWND_Inicio;


        public Form1()
        {
            InitializeComponent();
        }

        private void Ocultar(IntPtr HWND)
        {
            ShowWindow(HWND, SW_HIDE);
        }

        private void Mostrar(IntPtr HWND)
        {
            ShowWindow(HWND, SW_NORMAL);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //formulario------------------------------
            if (checkBox1.Checked)
                Ocultar(HWND_TaskBar);
            else
                Mostrar(HWND_TaskBar);

            if (checkBox2.Checked)
                Ocultar(HWND_TrayNotify);
            else
                Mostrar(HWND_TrayNotify);

            if (checkBox3.Checked)
                Ocultar(HWND_Iconos);
            else
                Mostrar(HWND_Iconos);

            if (checkBox4.Checked)
                Ocultar(HWND_Reloj);
            else
                Mostrar(HWND_Reloj);

            if (checkBox5.Checked)
                Ocultar(HWND_Inicio);
            else
                Mostrar(HWND_Inicio);
        }







        private void Form1_Load(object sender, EventArgs e)
        {
            HWND_TaskBar = FindWindow("Shell_TrayWnd", null);
            HWND_TrayNotify = FindWindowEx(HWND_TaskBar, 0, "TrayNotifyWnd", null);
            HWND_Iconos = FindWindowEx(HWND_TrayNotify, 0, "Syspager", null);
            HWND_Reloj = FindWindowEx(HWND_TrayNotify, 0, "TrayClockWClass", null);
            HWND_Inicio = FindWindowEx(HWND_TaskBar, 0, "BUTTON", null);
        }
    }
}
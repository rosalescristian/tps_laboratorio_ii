﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Al iniciar la calculadora limpia los valores existentes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        /// <summary>
        /// Al hacer Click en el botón operar toma los valores de los txtBoxs y CmbBox. Ejecuta el cálculo, muestra el resultado en el lblResultado y publica la linea en el listBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            string numeroUno = this.txtNumero1.Text;
            string numeroDos = this.txtNumero2.Text;
            string operacion = this.cmbOperador.GetItemText(this.cmbOperador.SelectedItem);
            string calculadora;
            string resultado = Operar(numeroUno, numeroDos, operacion).ToString();
            this.lblResultado.Text = resultado;
            calculadora = $"{numeroUno} {operacion} {numeroDos} = {resultado}";
            this.lstOperaciones.Items.Add(calculadora);
        }

        /// <summary>
        /// Al hacer click en el boton cerrar llama a FormClosing()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Valida si el usuario está seguro de salir o no.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Seguro de querer salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Recupera el valor del lblResultado si existe y de ser posible lo Convierte a Binario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            string resultado = this.lblResultado.Text;
            if (resultado != "Resultado")
            {
                resultado = Operando.DecimalBinario(resultado);
                this.lblResultado.Text = resultado;
            }
            
        }

        /// <summary>
        /// Recupera el valor del lblResultado si existe y de ser posible lo Convierte a Decimal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            string resultado = this.lblResultado.Text;
            if (resultado != "Resultado")
            {
                resultado = Operando.BinarioDecimal(resultado);
                this.lblResultado.Text = resultado;
            }
        }

        /// <summary>
        /// Al hacer click llama al método Limpiar para resetear todos los valores
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        /// <summary>
        /// Restablece los txtBoxes ,el cmbBox y el lblResultado a su estado por defecto.
        /// </summary>
        private void Limpiar()
        {
            this.txtNumero1.Text = String.Empty;
            //this.cmbOperador.Items.Clear();
            //this.cmbOperador.Items.AddRange(new string[] { "", "+", "-", "/", "*" });
            //this.cmbOperador.ResetText();
            this.txtNumero2.Text = String.Empty;
            this.lblResultado.Text = String.Empty;
        }

        /// <summary>
        /// Recupera los valores de los txtBoxes, cmbBox y ejecuta Calculadora.Operar()
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns>Devuelve el resultado de la operacion en tipo DOUBLE</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            double resultado;
            
            Operando numeroUno = new Operando(numero1);
            Operando numeroDos = new Operando(numero2);
            char operacion = Convert.ToChar(operador);
            
            resultado = Calculadora.Operar(numeroUno, numeroDos, operacion);
            
            return resultado;
        }
    }
}
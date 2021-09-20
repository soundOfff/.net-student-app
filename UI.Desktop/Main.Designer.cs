
namespace UI.Desktop
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.pnlVertical = new System.Windows.Forms.Panel();
            this.lblTipoPersona = new System.Windows.Forms.Label();
            this.lblNombrePersona = new System.Windows.Forms.Label();
            this.lbl5 = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnExamenes = new System.Windows.Forms.Button();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.pctrLogo = new System.Windows.Forms.PictureBox();
            this.pnlTitulo = new System.Windows.Forms.Panel();
            this.pctrMinimizar = new System.Windows.Forms.PictureBox();
            this.pctrMaximizar = new System.Windows.Forms.PictureBox();
            this.pctrMenu = new System.Windows.Forms.PictureBox();
            this.pctrSalir = new System.Windows.Forms.PictureBox();
            this.pnlContenedor = new System.Windows.Forms.Panel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lblPosNombre = new System.Windows.Forms.Label();
            this.lblPosTipo = new System.Windows.Forms.Label();
            this.lblPosImg = new System.Windows.Forms.Label();
            this.cirPicImg = new UI.Desktop.Clases.CircularPictureBox();
            this.pnlVertical.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctrLogo)).BeginInit();
            this.pnlTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctrMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctrMaximizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctrMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctrSalir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cirPicImg)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlVertical
            // 
            this.pnlVertical.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(10)))), ((int)(((byte)(103)))));
            this.pnlVertical.Controls.Add(this.lblTipoPersona);
            this.pnlVertical.Controls.Add(this.lblNombrePersona);
            this.pnlVertical.Controls.Add(this.lblPosImg);
            this.pnlVertical.Controls.Add(this.lblPosTipo);
            this.pnlVertical.Controls.Add(this.lblPosNombre);
            this.pnlVertical.Controls.Add(this.cirPicImg);
            this.pnlVertical.Controls.Add(this.lbl5);
            this.pnlVertical.Controls.Add(this.btnLogout);
            this.pnlVertical.Controls.Add(this.button3);
            this.pnlVertical.Controls.Add(this.button2);
            this.pnlVertical.Controls.Add(this.btnExamenes);
            this.pnlVertical.Controls.Add(this.btnUsuarios);
            this.pnlVertical.Controls.Add(this.pctrLogo);
            this.pnlVertical.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlVertical.Location = new System.Drawing.Point(0, 0);
            this.pnlVertical.Name = "pnlVertical";
            this.pnlVertical.Size = new System.Drawing.Size(200, 600);
            this.pnlVertical.TabIndex = 0;
            // 
            // lblTipoPersona
            // 
            this.lblTipoPersona.AutoSize = true;
            this.lblTipoPersona.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoPersona.ForeColor = System.Drawing.Color.White;
            this.lblTipoPersona.Location = new System.Drawing.Point(12, 103);
            this.lblTipoPersona.Name = "lblTipoPersona";
            this.lblTipoPersona.Size = new System.Drawing.Size(38, 13);
            this.lblTipoPersona.TabIndex = 6;
            this.lblTipoPersona.Text = "label1";
            // 
            // lblNombrePersona
            // 
            this.lblNombrePersona.AutoSize = true;
            this.lblNombrePersona.BackColor = System.Drawing.Color.Transparent;
            this.lblNombrePersona.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombrePersona.ForeColor = System.Drawing.Color.White;
            this.lblNombrePersona.Location = new System.Drawing.Point(12, 78);
            this.lblNombrePersona.Name = "lblNombrePersona";
            this.lblNombrePersona.Size = new System.Drawing.Size(38, 13);
            this.lblNombrePersona.TabIndex = 0;
            this.lblNombrePersona.Text = "label1";
            // 
            // lbl5
            // 
            this.lbl5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.lbl5.FlatAppearance.BorderSize = 0;
            this.lbl5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lbl5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lbl5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl5.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl5.ForeColor = System.Drawing.Color.White;
            this.lbl5.Image = ((System.Drawing.Image)(resources.GetObject("lbl5.Image")));
            this.lbl5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl5.Location = new System.Drawing.Point(12, 239);
            this.lbl5.Name = "lbl5";
            this.lbl5.Size = new System.Drawing.Size(180, 40);
            this.lbl5.TabIndex = 5;
            this.lbl5.Text = "Usuario";
            this.lbl5.UseVisualStyleBackColor = true;
            this.lbl5.Click += new System.EventHandler(this.lbl5_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnLogout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Image = ((System.Drawing.Image)(resources.GetObject("btnLogout.Image")));
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Location = new System.Drawing.Point(12, 423);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(180, 40);
            this.btnLogout.TabIndex = 4;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // button3
            // 
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(12, 377);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(180, 40);
            this.button3.TabIndex = 3;
            this.button3.Text = "Usuarios";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(12, 331);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(180, 40);
            this.button2.TabIndex = 2;
            this.button2.Text = "Usuarios";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btnExamenes
            // 
            this.btnExamenes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExamenes.FlatAppearance.BorderSize = 0;
            this.btnExamenes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnExamenes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnExamenes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExamenes.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExamenes.ForeColor = System.Drawing.Color.White;
            this.btnExamenes.Image = ((System.Drawing.Image)(resources.GetObject("btnExamenes.Image")));
            this.btnExamenes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExamenes.Location = new System.Drawing.Point(12, 285);
            this.btnExamenes.Name = "btnExamenes";
            this.btnExamenes.Size = new System.Drawing.Size(180, 40);
            this.btnExamenes.TabIndex = 1;
            this.btnExamenes.Text = "  Examenes";
            this.btnExamenes.UseVisualStyleBackColor = true;
            this.btnExamenes.Click += new System.EventHandler(this.btnExamenes_Click);
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnUsuarios.FlatAppearance.BorderSize = 0;
            this.btnUsuarios.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnUsuarios.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsuarios.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsuarios.ForeColor = System.Drawing.Color.White;
            this.btnUsuarios.Image = ((System.Drawing.Image)(resources.GetObject("btnUsuarios.Image")));
            this.btnUsuarios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsuarios.Location = new System.Drawing.Point(12, 193);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(180, 40);
            this.btnUsuarios.TabIndex = 0;
            this.btnUsuarios.Text = "Usuarios";
            this.btnUsuarios.UseVisualStyleBackColor = true;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // pctrLogo
            // 
            this.pctrLogo.Image = ((System.Drawing.Image)(resources.GetObject("pctrLogo.Image")));
            this.pctrLogo.Location = new System.Drawing.Point(-2, 3);
            this.pctrLogo.Name = "pctrLogo";
            this.pctrLogo.Size = new System.Drawing.Size(194, 47);
            this.pctrLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctrLogo.TabIndex = 0;
            this.pctrLogo.TabStop = false;
            // 
            // pnlTitulo
            // 
            this.pnlTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(10)))), ((int)(((byte)(103)))));
            this.pnlTitulo.Controls.Add(this.pctrMinimizar);
            this.pnlTitulo.Controls.Add(this.pctrMaximizar);
            this.pnlTitulo.Controls.Add(this.pctrMenu);
            this.pnlTitulo.Controls.Add(this.pctrSalir);
            this.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitulo.Location = new System.Drawing.Point(200, 0);
            this.pnlTitulo.Name = "pnlTitulo";
            this.pnlTitulo.Size = new System.Drawing.Size(700, 50);
            this.pnlTitulo.TabIndex = 1;
            this.pnlTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTitulo_MouseDown);
            // 
            // pctrMinimizar
            // 
            this.pctrMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pctrMinimizar.Image = ((System.Drawing.Image)(resources.GetObject("pctrMinimizar.Image")));
            this.pctrMinimizar.Location = new System.Drawing.Point(610, 3);
            this.pctrMinimizar.Name = "pctrMinimizar";
            this.pctrMinimizar.Size = new System.Drawing.Size(25, 25);
            this.pctrMinimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctrMinimizar.TabIndex = 2;
            this.pctrMinimizar.TabStop = false;
            this.pctrMinimizar.Click += new System.EventHandler(this.pctrMinimizar_Click);
            // 
            // pctrMaximizar
            // 
            this.pctrMaximizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pctrMaximizar.Image = ((System.Drawing.Image)(resources.GetObject("pctrMaximizar.Image")));
            this.pctrMaximizar.Location = new System.Drawing.Point(641, 3);
            this.pctrMaximizar.Name = "pctrMaximizar";
            this.pctrMaximizar.Size = new System.Drawing.Size(25, 25);
            this.pctrMaximizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctrMaximizar.TabIndex = 3;
            this.pctrMaximizar.TabStop = false;
            this.pctrMaximizar.Click += new System.EventHandler(this.pctrMaximizar_Click);
            // 
            // pctrMenu
            // 
            this.pctrMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pctrMenu.Image = ((System.Drawing.Image)(resources.GetObject("pctrMenu.Image")));
            this.pctrMenu.Location = new System.Drawing.Point(3, 7);
            this.pctrMenu.Name = "pctrMenu";
            this.pctrMenu.Size = new System.Drawing.Size(40, 40);
            this.pctrMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctrMenu.TabIndex = 0;
            this.pctrMenu.TabStop = false;
            this.pctrMenu.Click += new System.EventHandler(this.pctrMenu_Click);
            // 
            // pctrSalir
            // 
            this.pctrSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pctrSalir.Image = ((System.Drawing.Image)(resources.GetObject("pctrSalir.Image")));
            this.pctrSalir.Location = new System.Drawing.Point(672, 3);
            this.pctrSalir.Name = "pctrSalir";
            this.pctrSalir.Size = new System.Drawing.Size(25, 25);
            this.pctrSalir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctrSalir.TabIndex = 1;
            this.pctrSalir.TabStop = false;
            this.pctrSalir.Click += new System.EventHandler(this.pctrSalir_Click);
            // 
            // pnlContenedor
            // 
            this.pnlContenedor.BackColor = System.Drawing.Color.Gray;
            this.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenedor.Location = new System.Drawing.Point(200, 50);
            this.pnlContenedor.Name = "pnlContenedor";
            this.pnlContenedor.Size = new System.Drawing.Size(700, 550);
            this.pnlContenedor.TabIndex = 2;
            // 
            // lblPosNombre
            // 
            this.lblPosNombre.AutoSize = true;
            this.lblPosNombre.Location = new System.Drawing.Point(12, 130);
            this.lblPosNombre.Name = "lblPosNombre";
            this.lblPosNombre.Size = new System.Drawing.Size(0, 13);
            this.lblPosNombre.TabIndex = 7;
            // 
            // lblPosTipo
            // 
            this.lblPosTipo.AutoSize = true;
            this.lblPosTipo.Location = new System.Drawing.Point(12, 160);
            this.lblPosTipo.Name = "lblPosTipo";
            this.lblPosTipo.Size = new System.Drawing.Size(0, 13);
            this.lblPosTipo.TabIndex = 8;
            // 
            // lblPosImg
            // 
            this.lblPosImg.AutoSize = true;
            this.lblPosImg.Location = new System.Drawing.Point(10, 75);
            this.lblPosImg.Name = "lblPosImg";
            this.lblPosImg.Size = new System.Drawing.Size(0, 13);
            this.lblPosImg.TabIndex = 9;
            // 
            // cirPicImg
            // 
            this.cirPicImg.Image = ((System.Drawing.Image)(resources.GetObject("cirPicImg.Image")));
            this.cirPicImg.Location = new System.Drawing.Point(73, 56);
            this.cirPicImg.Name = "cirPicImg";
            this.cirPicImg.Size = new System.Drawing.Size(75, 75);
            this.cirPicImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cirPicImg.TabIndex = 0;
            this.cirPicImg.TabStop = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.pnlContenedor);
            this.Controls.Add(this.pnlTitulo);
            this.Controls.Add(this.pnlVertical);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.Shown += new System.EventHandler(this.Main_Shown);
            this.pnlVertical.ResumeLayout(false);
            this.pnlVertical.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctrLogo)).EndInit();
            this.pnlTitulo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctrMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctrMaximizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctrMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctrSalir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cirPicImg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlVertical;
        private System.Windows.Forms.PictureBox pctrLogo;
        private System.Windows.Forms.Panel pnlTitulo;
        private System.Windows.Forms.PictureBox pctrMenu;
        private System.Windows.Forms.Panel pnlContenedor;
        private System.Windows.Forms.PictureBox pctrMinimizar;
        private System.Windows.Forms.PictureBox pctrMaximizar;
        private System.Windows.Forms.PictureBox pctrSalir;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.Button lbl5;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnExamenes;
        private System.Windows.Forms.Label lblNombrePersona;
        private System.Windows.Forms.Label lblTipoPersona;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Clases.CircularPictureBox cirPicImg;
        private System.Windows.Forms.Label lblPosImg;
        private System.Windows.Forms.Label lblPosTipo;
        private System.Windows.Forms.Label lblPosNombre;
    }
}
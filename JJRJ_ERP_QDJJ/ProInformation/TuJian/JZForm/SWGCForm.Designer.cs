﻿namespace GOLDSOFT.QDJJ.UI
{
    partial class SWGCForm
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
            this.components = new System.ComponentModel.Container();
            this.SWGCFLBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.QDDEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.QDQDBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridControlEx1 = new GOLDSOFT.QDJJ.UI.Controls.GridControlEx();
            this.gridView1 = new GOLDSOFT.QDJJ.UI.InfoGridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.popControl1 = new GOLDSOFT.QDJJ.UI.popControl();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SZBWrepositoryItemComboBox1 = new GOLDSOFT.QDJJ.UI.ComBoxBW();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SWGCFLBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QDDEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QDQDBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlEx1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SZBWrepositoryItemComboBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.gridControlEx1);
            // 
            // gridControlEx1
            // 
            this.gridControlEx1.DataSource = this.bindingSource1;
            this.gridControlEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlEx1.Location = new System.Drawing.Point(2, 2);
            this.gridControlEx1.MainView = this.gridView1;
            this.gridControlEx1.Name = "gridControlEx1";
            this.gridControlEx1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.popControl1,
            this.SZBWrepositoryItemComboBox1});
            this.gridControlEx1.Size = new System.Drawing.Size(912, 392);
            this.gridControlEx1.TabIndex = 0;
            this.gridControlEx1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControlEx1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gridControlEx1_MouseUp);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11});
            this.gridView1.GridControl = this.gridControlEx1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsCustomization.AllowColumnMoving = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            this.gridView1.CustomRowCellEditForEditing += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.gridView1_CustomRowCellEditForEditing);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(gridView1_CellValueChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "序号";
            this.gridColumn1.FieldName = "XH";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "分类";
            this.gridColumn3.ColumnEdit = this.popControl1;
            this.gridColumn3.FieldName = "FL";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 81;
            // 
            // popControl1
            // 
            this.popControl1.Appearance.Options.UseTextOptions = true;
            this.popControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.popControl1.AppearanceDisabled.Options.UseTextOptions = true;
            this.popControl1.AppearanceDisabled.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.popControl1.AppearanceDropDown.Options.UseTextOptions = true;
            this.popControl1.AppearanceDropDown.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.popControl1.AutoHeight = false;
            this.popControl1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.popControl1.ColName = null;
            this.popControl1.Name = "popControl1";
            this.popControl1.PopupFormMinSize = new System.Drawing.Size(0, 200);
            this.popControl1.RemoveDefaultColName = null;
            this.popControl1.onCurrentChanged += new GOLDSOFT.QDJJ.UI.popControl.CurrentChangedHanld(this.popControl1_onCurrentChanged);
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.Caption = "材料名称种类";
            this.gridColumn4.ColumnEdit = this.popControl1;
            this.gridColumn4.FieldName = "CLMCZL";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 81;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.Caption = "厚度（cm）、连接方式";
            this.gridColumn5.ColumnEdit = this.popControl1;
            this.gridColumn5.FieldName = "HDLJFS";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            this.gridColumn5.Width = 135;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn6.Caption = "管径（mm）";
            this.gridColumn6.ColumnEdit = this.popControl1;
            this.gridColumn6.FieldName = "GJ";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            this.gridColumn6.Width = 84;
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn7.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn7.Caption = "垫层种类";
            this.gridColumn7.ColumnEdit = this.popControl1;
            this.gridColumn7.FieldName = "DCZL";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 5;
            this.gridColumn7.Width = 69;
            // 
            // gridColumn8
            // 
            this.gridColumn8.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn8.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn8.Caption = "单位";
            this.gridColumn8.FieldName = "DW";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 6;
            this.gridColumn8.Width = 72;
            // 
            // gridColumn9
            // 
            this.gridColumn9.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn9.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn9.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn9.Caption = "实物工程量";
            this.gridColumn9.FieldName = "SWGCL";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 7;
            this.gridColumn9.Width = 72;
            // 
            // gridColumn10
            // 
            this.gridColumn10.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn10.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn10.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn10.Caption = "所在部位";
            this.gridColumn10.ColumnEdit = this.SZBWrepositoryItemComboBox1;
            this.gridColumn10.FieldName = "SZBW";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 8;
            this.gridColumn10.Width = 69;
            // 
            // SZBWrepositoryItemComboBox1
            // 
            this.SZBWrepositoryItemComboBox1.AutoHeight = false;
            this.SZBWrepositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SZBWrepositoryItemComboBox1.Name = "SZBWrepositoryItemComboBox1";
            // 
            // gridColumn11
            // 
            this.gridColumn11.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn11.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridColumn11.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn11.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn11.Caption = "备注";
            this.gridColumn11.FieldName = "BZ";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 9;
            this.gridColumn11.Width = 78;
            // 
            // SWGCForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(915, 440);
            this.Name = "SWGCForm";
            this.Text = "SWGCForm";
            this.Load += new System.EventHandler(this.SWGCForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SWGCFLBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QDDEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QDQDBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlEx1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SZBWrepositoryItemComboBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        //protected GOLDSOFT.QDJJ.UI.Controls.GridControlEx gridControlEx1;
        //private InfoGridView gridView1;
        //private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        //private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        //private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        //private popControl popControl1;
        //private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        //private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        //private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        //private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        //private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        //private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        //private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        //private ComBoxBW SZBWrepositoryItemComboBox1;
        //private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private System.Windows.Forms.BindingSource SWGCFLBindingSource;
        private System.Windows.Forms.BindingSource QDDEBindingSource;
        private System.Windows.Forms.BindingSource QDQDBindingSource;
        private GOLDSOFT.QDJJ.UI.Controls.GridControlEx gridControlEx1;
        private popControl popControl1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private ComBoxBW SZBWrepositoryItemComboBox1;
        private InfoGridView gridView1;
    }
}
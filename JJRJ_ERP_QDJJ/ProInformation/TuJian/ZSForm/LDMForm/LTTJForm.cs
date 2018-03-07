﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GOLDSOFT.QDJJ.COMMONS;
using DevExpress.XtraGrid;
using GLODSOFT.QDJJ.BUSINESS;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class LTTJForm : BaseUI
    {
        public LTTJForm()
        {
            InitializeComponent();
        }
        public LTTJForm(_UnitProject p_CUnitProject)
            : base(p_CUnitProject)
        {
            InitializeComponent();
        }
        private void LTTJForm_Load(object sender, EventArgs e)
        {
            OnlyOneDataSource();//绑定数据源
        }
        public override object Parm
        {
            get
            {
                return base.Parm;
            }
            set
            {
                this.gridView1.Columns["BZ"].Visible = APP.SHOW_BZ;//隐藏备注列
                base.Parm = value;
                //this.ArrCheckMess = new string[] { "分类", "面层分类", "垫层材料名称" };
                //this.ArrCheckColl = new string[] { "FL", "MCFL", "DCCLMC" };
                this.ArrCheckMess = new string[] { "分类", "面层分类" };
                this.ArrCheckColl = new string[] { "FL", "MCFL" };

                ScreenWDBH(false);///添加筛选清单
                btnAddRow.Caption = "添加" + Parm + "信息";
                this.RemoveNull();///清除无效数据
            }
        }

        #region 绑定数据源
        private void OnlyOneDataSource()
        {
            this.LDMFLQDQDbindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["楼地面分类确定清单"];
            this.DCQDDEbindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["垫层确定定额"];
            this.ZPCQDDEbindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["找平层确定定额"];
            this.MCQDDEbindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["面层确定定额"];
            this.FHTQDDEbindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["防滑条确定定额"];
            this.bindingSource1.DataSource = InfTable.LTTJ;///楼梯台阶
            this.InfTable.LTTJ.RowChanged += new DataRowChangeEventHandler(this.RowChanged);//楼梯台阶
        }
        #endregion

        #region 操作

        #region 确认清单编号
        /// <summary>
        /// 选择发生改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            ScreenWDBH(false);///添加筛选清单
        }
        /// <summary>
        /// 确认清单编号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void btnScreenQDBH_Click(object sender, EventArgs e)
        {
            DataRowView currRow = this.bindingSource1.Current as DataRowView;
            if (currRow == null) { return; }
            base.btnScreenQDBH_Click(sender, e);
            //if (!string.IsNullOrEmpty(toString(currRow["DCHD"])))
            //{
            //    CheckNull("DCCLMC", "垫层材料名称");
            //}

            this.ZPCQDDEbindingSource.Filter = "CLMC='" + currRow["ZPCCLMC"] + "' and HD is not null";
            if (ZPCQDDEbindingSource.Count > 0)
            {
                CheckNull("ZPCHD", "找平层厚度");
            }
            //this.MCQDDEbindingSource.Filter = "FL='" + currRow["FL"] + "' and MCZL='" + currRow["MCFL"] + "' and MCCL is not null";
            //if (MCQDDEbindingSource.Count > 0)
            //{
            //    CheckNull("MCCLFL", "面层材料种类");
            //}
            if (this.CheckResult)
            {
                return;
            }
            ScreenWDBH(true);
            btnRefreshQDMC_Click(sender, e);
        }

        #region 添加筛选清单
        /// <summary>
        /// 添加筛选清单
        /// </summary>
        /// <param name="isAdd">是否添加</param>
        private void ScreenWDBH(bool isAdd)
        {
            try
            {
                if (null == this.bindingSource1.Current)
                {
                    this.InformationForm.Fiter(" 1<>1 ");
                    return;
                }
                DataRowView drCurrent = this.bindingSource1.Current as DataRowView;
                //string strTJ = string.Format("{0}[{1}]", drCurrent["FormMC"], drCurrent["ID"]);//条件  清单、子目标识
                string strTJ = "";
                if (string.IsNullOrEmpty(drCurrent["BZ"].ToString()))
                {
                    strTJ = DateTime.Now.ToString("yyyyMMddHHmmssffff") + "G" + APP.GoldSoftClient.GlodSoftDiscern.CurrNo + "G";
                    drCurrent["BZ"] = strTJ;
                }
                else
                {
                    strTJ = drCurrent["BZ"].ToString();
                }

                if (isAdd)
                {
                    #region 确定清单
                    string strQDWhere = string.Format("FL = '{0}' and MCZL= '{1}'", toString(drCurrent["FL"]), toString(drCurrent["MCFL"]));
                    this.LDMFLQDQDbindingSource.Filter = strQDWhere;
                    DataRow dr = APP.UnInformation.QDTable.NewRow();
                    if (0 < this.LDMFLQDQDbindingSource.Count)
                    {
                        DataRowView view = this.LDMFLQDQDbindingSource[0] as DataRowView;
                        dr["QDBH"] = view["QDBH"];
                        dr["QDMC"] = view["QDMC"];
                        dr["DW"] = view["QDDW"];
                        dr["XS"] = view["GCLXS"];
                        dr["GCL"] = ToolKit.ParseDecimal(dr["XS"]) * ToolKit.ParseDecimal(drCurrent["SWGCL"]);
                        dr["WZLX"] = WZLX.分部分项;
                        dr["TJ"] = strTJ;
                        if (toString(view["QDBH"]).Length > 5)
                        {
                            dr["ZJ"] = toString(view["QDBH"]).Substring(0, 6);//清单所属章节【清单编号前六位】
                        }
                    }
                    #endregion

                    #region 确定定额
                    List<DataRow> rows = new List<DataRow>();
                    StringBuilder sb = new StringBuilder();

                    #region 垫层确定定额
                    this.DCQDDEbindingSource.Filter = string.Format("DCCL = '{0}'", toString(drCurrent["DCCLMC"]));
                    foreach (DataRowView item in this.DCQDDEbindingSource)
                    {
                        DataRow row = APP.UnInformation.DETable.NewRow();
                        row["DEBH"] = item["DEBH"];
                        if (!string.IsNullOrEmpty(toString(item["CJMC"])))
                        {
                            row["DEMC"] = item["DEMC"] + "换：//" + item["CJMC"];
                        }
                        else
                        {
                            row["DEMC"] = item["DEMC"];
                        }
                        row["DW"] = item["DEDW"];
                        string[] strTemp = toString(item["GCLXS"]).Split('/');
                        if (strTemp.Length == 2)
                        {
                            row["XS"] = ToolKit.ParseDecimal(drCurrent["DCHD"]) / ToolKit.ParseDecimal(strTemp[1]);
                        }
                        else
                        {
                            row["XS"] = item["GCLXS"];
                        }
                        row["GCL"] = ToolKit.ParseDecimal(row["XS"]) * ToolKit.ParseDecimal(dr["GCL"]);
                        row["HSQ"] = item["HSQ"];
                        row["HSH"] = item["HSH"];
                        row["QDBH"] = dr["QDBH"];
                        row["TJ"] = strTJ;
                        row["WZLX"] = WZLX.分部分项;
                        rows.Add(row);
                        sb.Append(string.Format("{0},{1},{2},{3}|", item["DEBH"], row["XS"], item["HSQ"], item["HSH"]));
                    }
                    #endregion

                    #region 找平层确定定额
                    this.ZPCQDDEbindingSource.Filter = string.Format("CLMC = '{0}' and (HD is null or HD ='{1}')", toString(drCurrent["ZPCCLMC"]), toString(drCurrent["ZPCHD"]));
                    foreach (DataRowView item in this.ZPCQDDEbindingSource)
                    {
                        DataRow row = APP.UnInformation.DETable.NewRow();
                        row["DEBH"] = item["DEBH"];
                        row["DEMC"] = item["DEMC"];
                        row["DW"] = item["DEDW"];
                        row["XS"] = item["GCLXS"];
                        row["GCL"] = ToolKit.ParseDecimal(row["XS"]) * ToolKit.ParseDecimal(dr["GCL"]);
                        row["QDBH"] = dr["QDBH"];
                        row["TJ"] = strTJ;
                        row["WZLX"] = WZLX.分部分项;
                        rows.Add(row);
                        sb.Append(string.Format("{0},{1},{2},{3}|", item["DEBH"], item["GCLXS"], "", ""));
                    }
                    #endregion

                    #region 面层确定定额
                    this.MCQDDEbindingSource.Filter = string.Format("FL = '{0}' and MCZL='{1}' and (MCCL is null or MCCL ='{2}') and (JCCL is null or JCCL like '%,{3},%')"
                        , toString(drCurrent["FL"])
                        , toString(drCurrent["MCFL"])
                        , toString(drCurrent["MCCLZL"])
                        , toString(drCurrent["JCCL"]));
                    foreach (DataRowView item in this.MCQDDEbindingSource)
                    {
                        DataRow row = APP.UnInformation.DETable.NewRow();
                        row["DEBH"] = item["DEBH"];
                        row["DEMC"] = item["DEMC"];
                        row["DW"] = item["DEDW"];
                        if (toString(item["GCLXS"]) == "GCL/0.12/100")
                        {
                            row["XS"] = ToolKit.ParseDecimal(drCurrent["SWGCL"]) / ToolKit.ParseDecimal(0.12) / 100;
                        }
                        else
                        {
                            row["XS"] = item["GCLXS"];
                        }
                        row["GCL"] = ToolKit.ParseDecimal(row["XS"]) * ToolKit.ParseDecimal(dr["GCL"]);
                        row["QDBH"] = dr["QDBH"];
                        row["TJ"] = strTJ;
                        row["WZLX"] = WZLX.分部分项;
                        rows.Add(row);
                        sb.Append(string.Format("{0},{1},{2},{3}|", item["DEBH"], row["XS"], "", ""));
                    }
                    #endregion

                    #region 防滑条确定定额
                    this.FHTQDDEbindingSource.Filter = string.Format("FHTMC='{0}' ", toString(drCurrent["FHT"]));
                    foreach (DataRowView item in this.FHTQDDEbindingSource)
                    {
                        DataRow row = APP.UnInformation.DETable.NewRow();
                        row["DEBH"] = item["DEBH"];
                        row["DEMC"] = item["DEMC"];
                        row["DW"] = item["DEDW"];
                        row["XS"] = item["GCLXS"];
                        row["GCL"] = ToolKit.ParseDecimal(row["XS"]) * ToolKit.ParseDecimal(dr["GCL"]);
                        row["QDBH"] = dr["QDBH"];
                        row["TJ"] = strTJ;
                        row["WZLX"] = WZLX.分部分项;
                        rows.Add(row);
                        sb.Append(string.Format("{0},{1},{2},{3}|", item["DEBH"], item["GCLXS"], "", ""));
                    }
                    #endregion
                    #endregion

                    //dr["BZ"] = sb.ToString() + DateTime.Now.ToString("yyyyMMddHHmmssffff") + "G" + APP.GoldSoftClient.GlodSoftDiscern.CurrNo + "G";
                    if (string.IsNullOrEmpty(dr["TJ"].ToString()))
                    {
                        dr["BZ"] = sb.ToString() + strTJ;
                        dr["TJ"] = strTJ;
                    }
                    else
                    {
                        dr["BZ"] = sb.ToString() + dr["TJ"].ToString();
                    }
                    this.InformationForm.Remove(strTJ);
                    this.InformationForm.Add(dr, rows);
                }
                else
                {
                    //this.InformationForm.Fiter(string.Format("TJ='{0}[{1}]'", drCurrent["FormMC"], drCurrent["ID"]));///添加筛选清单
                    this.InformationForm.Fiter(string.Format("TJ='{0}'", strTJ));///添加筛选清单
                }
            }
            catch (Exception ex)
            {
                DebugErr(ex.Message);
            }
        }
        #endregion
        #endregion

        #region 刷新清单名称
        /// <summary>
        /// 刷新清单名称
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void btnRefreshQDMC_Click(object sender, EventArgs e)
        {
            if (null == this.bindingSource1.Current) return;
            DataRowView drCurrent = this.bindingSource1.Current as DataRowView;
            string strKey = "项目特征";
            string strContent = "【项目特征】";
            int i = 0;
            if (!string.IsNullOrEmpty(drCurrent["MCFL"].ToString()) || !string.IsNullOrEmpty(drCurrent["FL"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".面层分类：" + drCurrent["FL"] + "　" + drCurrent["MCFL"];
            }
            if (!string.IsNullOrEmpty(drCurrent["DCCLMC"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".垫层材料名称、厚度：" + drCurrent["DCCLMC"];
            }
            if (!string.IsNullOrEmpty(drCurrent["DCHD"].ToString()))
            {
                strContent += drCurrent["DCHD"] + "mm";
            }
            if (!string.IsNullOrEmpty(drCurrent["ZPCCLMC"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".找平层材料名称、厚度：" + drCurrent["ZPCCLMC"];
            }
            if (!string.IsNullOrEmpty(drCurrent["ZPCHD"].ToString()))
            {
                strContent += drCurrent["ZPCHD"] + "mm";
            }

            if (!string.IsNullOrEmpty(drCurrent["MCCLZL"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".面层材料种类：" + drCurrent["MCCLZL"];
            }
            if (!string.IsNullOrEmpty(drCurrent["JCCL"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".基层材料：" + drCurrent["JCCL"];
            }
            if (!string.IsNullOrEmpty(drCurrent["FHT"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".防滑条：" + drCurrent["FHT"];
            }
            if (!string.IsNullOrEmpty(drCurrent["SZBW"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".所在部位：" + drCurrent["SZBW"];
            }
            this.InformationForm.SetFixedName(strKey, strContent);
        }
        #endregion

        #region 鼠标点击【右键处理】
        /// <summary>
        /// 鼠标点击【右键处理】
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridControlEx1_MouseUp(object sender, MouseEventArgs e)
        {
            SetPopBar(sender as GridControl, e);
        }
        #endregion

        #endregion

        private void gridView1_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            DataRowView currRow = this.bindingSource1.Current as DataRowView;
            if (null == currRow) { return; }
            popControl1.PopupControl.Size = new Size(e.Column.Width, popControl1.PopupControl.Height);
            switch (e.Column.FieldName)
            {
                case "FL":
                    this.LDMFLQDQDbindingSource.Filter = " FL = '楼梯' or FL='台阶'";
                    popControl1.DataSource = (this.LDMFLQDQDbindingSource.DataSource as DataTable).DefaultView.ToTable(true, "FL");
                    popControl1.ColName = new string[] { "分类|FL|FL" };
                    popControl1.RemoveDefaultColName = new string[] { "MCFL", "MCCLZL", "JCCL" };
                    popControl1.bind();
                    break;
                case "MCFL":
                    popControl1.DataSource = this.LDMFLQDQDbindingSource;
                    this.LDMFLQDQDbindingSource.Filter = " FL = '" + currRow["FL"] + "'";
                    popControl1.ColName = new string[] { "面层分类|MCZL|MCFL" };
                    popControl1.RemoveDefaultColName = new string[] { "MCCLZL", "JCCL" };
                    popControl1.bind();
                    break;
                case "DCCLMC":
                    popControl1.DataSource = this.DCQDDEbindingSource;
                    this.DCQDDEbindingSource.Filter = "";
                    popControl1.ColName = new string[] { "垫层材料名称|DCCL|DCCLMC" };
                    popControl1.bind();
                    break;
                case "ZPCCLMC":
                    this.ZPCQDDEbindingSource.Filter = "";
                    popControl1.DataSource = (this.ZPCQDDEbindingSource.DataSource as DataTable).DefaultView.ToTable(true, "CLMC");
                    popControl1.ColName = new string[] { "找平层材料名称|CLMC|ZPCCLMC" };
                    popControl1.RemoveDefaultColName = new string[] { "ZPCHD" };
                    popControl1.bind();
                    break;
                case "ZPCHD":
                    popControl1.DataSource = this.ZPCQDDEbindingSource;
                    this.ZPCQDDEbindingSource.Filter = "CLMC='" + currRow["ZPCCLMC"] + "' and HD is not null";
                    popControl1.ColName = new string[] { "找平层厚度|HD|ZPCHD" };
                    popControl1.bind();
                    break;
                case "MCCLZL":
                    this.MCQDDEbindingSource.Filter = "FL='" + currRow["FL"] + "' and MCZL='" + currRow["MCFL"] + "'";
                    popControl1.DataSource = (this.MCQDDEbindingSource.DataSource as DataTable).DefaultView.ToTable(true, "MCCL");
                    popControl1.ColName = new string[] { "面层材料种类|MCCL|MCCLZL" };
                    popControl1.RemoveDefaultColName = new string[] { "JCCL" };
                    popControl1.bind();
                    break;
                case "JCCL":
                    popControl1.DataSource = ReturnDtJCCL(currRow);
                    popControl1.ColName = new string[] { "基层材料|JCCL|JCCL" };
                    popControl1.bind();
                    break;
                case "FHT":
                    popControl1.DataSource = this.FHTQDDEbindingSource;
                    this.FHTQDDEbindingSource.Filter = "";
                    popControl1.ColName = new string[] { "防滑条|FHTMC|FHT" };
                    popControl1.bind();
                    break;
            }
        }
        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DataRowView currRow = this.bindingSource1.Current as DataRowView;
            if (null == currRow) { return; }
            popControl1.PopupControl.Size = new Size(e.Column.Width, popControl1.PopupControl.Height);
            switch (e.Column.FieldName)
            {
                case "SZBW":
                    string val = e.Value.ToString();
                    foreach (string item in this.SZBWrepositoryItemComboBox1.Items)
                    {
                        if (item.Equals(val))
                            return;
                    }

                    this.SZBWrepositoryItemComboBox1.SaveCusotmerValue(val);

                    break;
            }
        }
        private void popControl1_onCurrentChanged(popControl Sender, DataRowView CurrRowView)
        {
            this.bindPopReturn(Sender, CurrRowView);
            this.gridView1.HideEditor();
            DataRowView currRow = this.bindingSource1.Current as DataRowView;
            if (currRow == null) { return; }
            if (this.gridView1.FocusedColumn.FieldName == "MCCLZL")
            {
                DataTable dtTemp = ReturnDtJCCL(currRow);
                if (dtTemp.Rows.Count == 1)
                {
                    currRow["JCCL"] = dtTemp.Rows[0]["JCCL"];
                }
            }
        }

        /// <summary>
        /// 返回处理后的基层材料表
        /// </summary>
        /// <param name="currRow"></param>
        /// <returns></returns>
        private DataTable ReturnDtJCCL(DataRowView currRow)
        {
            this.MCQDDEbindingSource.Filter = "FL='" + currRow["FL"] + "' and MCZL='" + currRow["MCFL"] + "' and MCCL='" + currRow["MCCLZL"] + "' and JCCL is not null";
            DataTable dtTemp = new DataTable();
            foreach (DataRowView item in MCQDDEbindingSource)
            {
                this.strToTable(dtTemp, toString(item["JCCL"]), "JCCL");
            }
            this.RemoveRepeat(dtTemp, "JCCL");
            return dtTemp;
        }
    }
}

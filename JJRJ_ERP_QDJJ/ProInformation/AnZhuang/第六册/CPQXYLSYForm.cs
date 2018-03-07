﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GLODSOFT.QDJJ.BUSINESS;
using DevExpress.XtraGrid;
using GOLDSOFT.QDJJ.COMMONS;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class CPQXYLSYForm : BaseUI
    {
        public CPQXYLSYForm()
        {
            InitializeComponent();
        }

        private void CPQXYLSYForm_Load(object sender, EventArgs e)
        {
            OnlyOneDataSource();
        }
        public override object Parm
        {
            //验证必填项
            get
            {
                return base.Parm;
            }
            set
            {
                                this.gridView1.Columns["BZ"].Visible = APP.SHOW_BZ;//隐藏备注列
                base.Parm = value;
                ScreenWDBH(false);///添加筛选清单
                btnAddRow.Caption = "添加" + Parm + "信息";
                this.RemoveNull();///清除无效数据
            }
        }

        #region 绑定数据源
        private void OnlyOneDataSource()
        {
            this.bindingSource1.DataSource = InfTable.吹排清洗压力试验;
            this.InfTable.吹排清洗压力试验.RowChanged += new DataRowChangeEventHandler(this.RowChanged);

            this.GYGDQDDEBindingSource.DataSource = APP.Application.Global.DataTamp.安装专业工程信息表.Tables["工业管道确定定额"];
            this.GDQDQDBindingSource.DataSource = APP.Application.Global.DataTamp.安装专业工程信息表.Tables["管道确定清单"];
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
            if (null == this.bindingSource1.Current) return;
            //必填性验证
            checkeArr();
            base.btnScreenQDBH_Click(sender, e);
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
                    string strQDWhere = string.Format("FL like '%{0}%'", drCurrent["FL"]);
                    this.GDQDQDBindingSource.Filter = strQDWhere;
                    DataRow dr = APP.UnInformation.QDTable.NewRow();
                    if (0 < this.GDQDQDBindingSource.Count)
                    {
                        DataRowView view = this.GDQDQDBindingSource[0] as DataRowView;
                        dr["QDBH"] = view["QDBH"];
                        dr["QDMC"] = view["QDMC"];
                        dr["DW"] = view["QDDW"];
                        dr["XS"] = view["GCLXS"];
                        dr["GCL"] = ToolKit.ParseDecimal(drCurrent["SWGCL"]);
                        dr["TJ"] = strTJ;
                        if (toString(view["QDBH"]).Length > 5)
                        {
                            dr["ZJ"] = toString(view["QDBH"]).Substring(0, 6);//清单所属章节【清单编号前六位】
                        }
                    }
                    this.GDQDQDBindingSource.Filter = "";///清单取完以后  条件置回空；
                    #endregion

                    #region 确定定额
                    List<DataRow> rows = new List<DataRow>();
                    StringBuilder sb = new StringBuilder();

                    #region 电气确定定额

                    StringBuilder strString = new StringBuilder(" LB = '吹排与清洗,管道压力试验'");
                    strString.Append(string.IsNullOrEmpty(toString(drCurrent["FL"])) ? " and FL is null" : string.Format(" and FL='{0}'", drCurrent["FL"]))
                             .Append(string.IsNullOrEmpty(toString(drCurrent["GCZJYN"])) ? " and LIJF is null" : string.Format(" and LJFS like '%,{0},%'", drCurrent["GCZJYN"]));
                    this.GYGDQDDEBindingSource.Filter = strString.ToString();

                    foreach (DataRowView item in this.GYGDQDDEBindingSource)
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
                        sb.Append(string.Format("{0},{1},{2},{3}|", row["DEBH"], row["XS"], "", ""));
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
            if (!string.IsNullOrEmpty(drCurrent["FL"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".吹排与清洗,管道压力试验分类：" + drCurrent["FL"];
            }
            if (!string.IsNullOrEmpty(drCurrent["GCZJYN"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".公称直径(mm)以内：" + drCurrent["GCZJYN"];
            }
            this.InformationForm.SetFixedName(strKey, strContent);
        }
        #endregion


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
            StringBuilder strString = null;
            popControl1.PopupControl.Size = new Size(e.Column.Width, popControl1.PopupControl.Height);
            switch (e.Column.FieldName)
            {
                case "FL":
                    this.GYGDQDDEBindingSource.Filter = " LB = '吹排与清洗,管道压力试验' and FL is not null";
                    popControl1.DataSource = RemoveRepeat(GYGDQDDEBindingSource, "FL");

                    popControl1.ColName = new string[] { "名称|FL|FL" };
                    //清除依赖项数据
                    popControl1.RemoveDefaultColName = new string[] { "GCZJYN" };
                    popControl1.bind();
                    break;
                case "GCZJYN":
                    strString = new StringBuilder(" LB = '吹排与清洗,管道压力试验' and LJFS is not null");
                    strString.Append(string.IsNullOrEmpty(toString(currRow["FL"])) ? " and FL is null" : string.Format(" and FL='{0}'", currRow["FL"]));

                    this.GYGDQDDEBindingSource.Filter = strString.ToString();
                    popControl1.DataSource = RemoveRepeat(strToTable(GYGDQDDEBindingSource, "LJFS", ','), "LJFS");

                    popControl1.ColName = new string[] { "公称直径(mm)以内|LJFS|GCZJYN" };
                    popControl1.bind();
                    break;
            }
        }

        private void popControl1_onCurrentChanged(popControl Sender, DataRowView CurrRowView)
        {
            this.bindPopReturn(Sender, CurrRowView);
            this.gridView1.HideEditor();
            DataRowView drCurrent = this.bindingSource1.Current as DataRowView;

            //当可以确定唯一清单时   修正当前行单位
            string strQDWhere = string.Format("FL like '%{0}%'", drCurrent["FL"]);
            this.GDQDQDBindingSource.Filter = strQDWhere;
            if (0 < GDQDQDBindingSource.Count)
            {
                DataRowView view = this.GDQDQDBindingSource[0] as DataRowView;
                drCurrent["DW"] = view["QDDW"];
            }
        }
        //必填项验证
        private void checkeArr()
        {
            DataRowView currRow = this.bindingSource1.Current as DataRowView;
            StringBuilder strString = null;
            //判断是否已添加数据行
            if (currRow != null)
            {
                List<string> checkMess = new List<string>();
                List<string> CheckColl = new List<string>();
                //点击确定清单前   判断必填项
                this.GYGDQDDEBindingSource.Filter = " LB = '吹排与清洗,管道压力试验'";
                if (0 < GYGDQDDEBindingSource.Count)
                {
                    this.GYGDQDDEBindingSource.Filter = " LB = '吹排与清洗,管道压力试验' and FL is null";
                    if (1 > GYGDQDDEBindingSource.Count)
                    {
                        checkMess.Add("分类");
                        CheckColl.Add("FL");
                    }
                }
                strString = new StringBuilder(" LB = '吹排与清洗,管道压力试验'");
                strString.Append(string.IsNullOrEmpty(toString(currRow["FL"])) ? " and FL is null" : string.Format(" and FL='{0}'", currRow["FL"]));
                GYGDQDDEBindingSource.Filter = strString.ToString();
                if (0 < GYGDQDDEBindingSource.Count)
                {
                    strString.Append(" and LJFS is null");
                    this.GYGDQDDEBindingSource.Filter = strString.ToString();
                    if (1 > GYGDQDDEBindingSource.Count)
                    {
                        checkMess.Add("公称直径(mm)以内");
                        CheckColl.Add("GCZJYN");
                    }
                }
                ArrCheckColl = CheckColl.ToArray();
                ArrCheckMess = checkMess.ToArray();
            }
        }
    }
}
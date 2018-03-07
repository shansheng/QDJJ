﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GOLDSOFT.QDJJ.COMMONS;
using System.Data;

namespace GLODSOFT.QDJJ.BUSINESS
{
    /// <summary>
    /// 章的处理
    /// </summary>
    public class _Method_Chapt : _Methods
    {
        public _Method_Chapt(_UnitProject p_Unit)
            : base(p_Unit)
        {

        }

        public _Method_Chapt(_Business m_Currentbus, _UnitProject p_Unit, _Entity_SubInfo p_info)
            : base(m_Currentbus,p_Unit, p_info)
        {

        }
        public override void RemoveAllChild()
        {
            base.RemoveAllChild();
        }
        public override void RemoveChild(_Entity_SubInfo info)
        {
            base.RemoveChild(info);
        }
        public override void Begin(List<int> session)
        {
            if (session != null)
            {
                if (session.Contains(Current.ID))
                {
                    return;
                }
                else
                {
                    session.Add(Current.ID);
                }
            }

            _Entity_SubInfo info = null;
            DataRow row = null;
            _Methods met = null;

            _SubSegment_Statistics sta = new _SubSegment_Statistics(this.Current, this.Unit);
            sta.DataSource = this.GetDataSource;
            sta.Begin();

            //计算子目所属专业
            info = new _Entity_SubInfo();
            row = this.Unit.StructSource.ModelSubSegments.GetRowByOther(this.Current.PID.ToString());
            _ObjectSource.GetObject(info, row);
            met = new _Methods_Pro(this.CurrentBusiness,this.Unit, info);
            met.Begin(session);
        }

        public override void Calculate()
        {
            DataRow[] rows = this.GetDataSource.Select(string.Format("PID={0}", this.Current.ID), "", DataViewRowState.CurrentRows);
           
            foreach (DataRow item in rows)
            { 
                _Entity_SubInfo info = new _Entity_SubInfo();
                _ObjectSource.GetObject(info, item);
                _Method_Fest met = new _Method_Fest(this.CurrentBusiness,this.Unit,info);
                met.Calculate();
            }
            _SubSegment_Statistics sta = new _SubSegment_Statistics(this.Current, this.Unit);
            sta.DataSource = this.GetDataSource;
            sta.Begin();

        }
        public override void BeginCurrent()
        {
            _SubSegment_Statistics sta = new _SubSegment_Statistics(this.Current, this.Unit);
            sta.DataSource = this.GetDataSource;
            sta.Begin();
        }
    }
}

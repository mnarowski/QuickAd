using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuickAd.Models;
using System.Web.Mvc;
using QuickAd.Models.DBO;
using NHibernate.Mapping;
using System.Linq.Expressions;

namespace QuickAd.ViewHelpers
{
    public static class QHtmlHelper
    {
        public static MvcHtmlString BuildSelectCategories(this HtmlHelper helper, int selected, string name, string _class)
        {
            return MvcHtmlString.Create(String.Format("<select name='{0}' class='{1}'>{2}</select>", name, _class,GetAsOptionsCategory(selected)));
        }

        public static string GetAsOptionsCategory(int selected) { 
            string res = "";
            List<AdvertCategory> models = DBHelper.GetAll<AdvertCategory>();
            string frmt = "<option name=\"{0}\" title=\"{0}\" value=\"{1}\">{0}</option>";
            string frmt_selected = "<option name=\"{0}\" title=\"{0}\" value=\"{1}\" selected=\"selected\">{0}</option>";
            foreach(AdvertCategory m in models){
                if(m.GetId() == selected){
                    res+= String.Format(frmt_selected,m.GetName(),m.GetId());
                    continue;
                }
                res+= String.Format(frmt,m.GetName(),m.GetId());
            }

            return res;
        }


        public static MvcHtmlString BuildSelectRegion(this HtmlHelper helper, int selected, string name, string _class)
        {
            return MvcHtmlString.Create(String.Format("<select name='{0}' class='{1}'>{2}</select>", name, _class, GetAsOptionsRegion(selected)));
        }

        public static string GetAsOptionsRegion(int selected)
        {
            string res = "";
            List<Territory> models = DBHelper.GetAll<Territory>();
            string frmt = "<option name=\"{0}\" title=\"{0}\" value=\"{1}\">{0}</option>";
            string frmt_selected = "<option name=\"{0}\" title=\"{0}\" value=\"{1}\" selected=\"selected\">{0}</option>";
            foreach (Territory m in models)
            {
                if (m.GetId() == selected)
                {
                    res += String.Format(frmt_selected, m.GetName(), m.GetId());
                    continue;
                }
                res += String.Format(frmt, m.GetName(), m.GetId());
            }

            return res;
        }


        public static MvcHtmlString GetTerritoryId(this HtmlHelper helper, Territory t) {
            return MvcHtmlString.Create(String.Format("{0}", t.GetId()));
        }

        public static MvcHtmlString GetCategoryId(this HtmlHelper helper, AdvertCategory ac) {
            return MvcHtmlString.Create(String.Format("{0}", ac.GetId()));
        }

        public static MvcHtmlString GetSexSelect(this HtmlHelper helper, int selected = 1) {
            string frmt = "<option name=\"{0}\" title=\"{0}\" value=\"{1}\">{0}</option>";
            string frmt_selected = "<option name=\"{0}\" title=\"{0}\" value=\"{1}\" selected=\"selected\">{0}</option>";
            string select = "<select name=\"VSex\">{0}</select>";
            string optionsString = "";
            if (selected == 1)
            {
                optionsString += String.Format(frmt_selected, "Mężczyzna", 1);
            }
            else {
                optionsString += String.Format(frmt, "Mężczyzna", 1);
            }

            if (selected == 2)
            {
                optionsString += String.Format(frmt_selected, "Kobieta", 2);
            }
            else
            {
                optionsString += String.Format(frmt, "Kobieta", 2);
            }

            return MvcHtmlString.Create(String.Format(select,optionsString));
        }
    }
}
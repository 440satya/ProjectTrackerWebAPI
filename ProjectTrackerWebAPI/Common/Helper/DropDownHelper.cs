using Project.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CompJar.Helpers
{
    public class DropDownHelper
    {
        public class DropDownModel
        {
            public string Text { get; set; }
            public int Value { get; set; }
        }


        //Usage -  ViewBag.CostMetricsList = DropDownHelper.GetMarialCostMetrics();
        // <select class="form-select form-control" asp-for="CostMetricsId" asp-items="@(new SelectList(ViewBag.CostMetricsList,"Text","Value"))"></select>

        public static List<DropDownModel> GetMarialCostMetrics()
        {
            List<DropDownModel> newList = new List<DropDownModel>();

            foreach (var item in Enum.GetValues<Constants.CostMetrics>())
            {
                newList.Insert(0, new DropDownModel { Text = item.ToString(), Value = (int)item });
            }

            return newList;
        }
        public static List<DropDownModel> GetCurrentStatus()
        {
            List<DropDownModel> newList = new List<DropDownModel>();

            foreach (var item in Enum.GetValues<Constants.CurrentStatus>())
            {
                newList.Insert(0, new DropDownModel { Text = item.ToString(), Value = (int)item });
            }

            return newList;
        }
        public static List<DropDownModel> GetFileStatus()
        {
            List<DropDownModel> newList = new List<DropDownModel>();

            foreach (var item in Enum.GetValues<Constants.FileStatus>())
            {
                newList.Insert(0, new DropDownModel { Text = item.ToString(), Value = (int)item });
            }

            return newList;
        }

        //public static List<State> GetStateDropDown(List<State> StateList)
        //{
        //    StateList.Insert(0, new State { StateId = 0, StateName = "-- Select State --" });
        //    return StateList;
        //}
    }
}

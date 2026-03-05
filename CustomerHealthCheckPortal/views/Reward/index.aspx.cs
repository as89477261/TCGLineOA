using BLL.Controller.HealthCheck;
using DataModel.Models.CustomerHealthModel.Reward;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomerHealthCheck.views.Reward
{
    public partial class index : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RenderRewardHeader();
                RenderReward();              
            }
        }

        private void RenderRewardHeader()
        {
            var lstRewardHeader = RewardHeaderCon.Instance.GetRewardByHeader(null, null, "1");
            if (lstRewardHeader.RESULT_STATUS == "OK" && lstRewardHeader.RESULT_OBJ.Count > 0)
            {
                for (int i = 0; i < lstRewardHeader.RESULT_OBJ.Count; i++)
                {
                    var bufferItem = "<a href='#' class='d-flex py-1' data-bs-toggle='offcanvas' data-bs-target='#menu-activity-1'>" +
                                     "<div class='align-self-center'> " +
                                     "<span class='icon me-2 shadow-bg shadow-bg-xs rounded-s'>" +
                                        "<img src='" + lstRewardHeader.RESULT_OBJ[i].LogoProgramPath + "' width='45' class='rounded-s' alt='img'>" +
                                            "</span>" +
                                        "</div>" +
                                        "<div class='align-self-center ps-1'>" +
                                            //"<input type=\"hidden\" name=\"name\" value=\"" + lstRewardHeader.RESULT_OBJ[i].StartDate.ToString("yyyy-MM-dd") + "\" id=\"" + lstRewardHeader.RESULT_OBJ[i].OwnerProgram + "_hddStartDate\" />" +
                                            //"<input type=\"hidden\" name=\"name\" value=\"" + lstRewardHeader.RESULT_OBJ[i].EndDate.ToString("yyyy-MM-dd") + "\" id=\"" + lstRewardHeader.RESULT_OBJ[i].OwnerProgram + "_hddEndDate\" />" +
                                            "<h5 class='pt-1 mb-n1'>" + lstRewardHeader.RESULT_OBJ[i].TitleProgram + "</h5>" +
                                            "<p class='mb-0 font-11 opacity-70'>" + lstRewardHeader.RESULT_OBJ[i].DescriptionProgram + "</p>" +
                                       "</div>";

                    if (lstRewardHeader.RESULT_OBJ[i].IsActive == true)
                    {
                        bufferItem += "<div class='align-self-center ms-auto text-end' onclick='ShowCondition(\"" + lstRewardHeader.RESULT_OBJ[i].RewardOwnerCode + "\",\"" + lstRewardHeader.RESULT_OBJ[i].RewardProgramCode + "\");'>" +
                                          "<span class='btn btn-xxs gradient-blue shadow-bg shadow-bg-xs'>รับคูปอง</span>" +
                                      "</div>";
                    }
                    else
                    {
                        bufferItem += "<div class='align-self-center ms-auto text-end' ;'>" +
                                          "<span class='btn btn-xxs gradient-blue shadow-bg shadow-bg-xs'>สิทธิ์เต็ม</span>" +
                                      "</div>";
                    }
                    bufferItem += "</a>";

                    ltlRewardHeaderItem.Text += bufferItem;
                }
                pnlRewardHeaderItem.Visible = true;
                pnlRewardHeaderEmpty.Visible = false;
            }
            else
            {
                pnlRewardHeaderItem.Visible = false;
                pnlRewardHeaderEmpty.Visible = true;
            }

        }
        private void RenderReward()
        {
            var uid = CookieManager.GetEncryptCookie("lineoa", "uid", GetAppsetting("APIPartialCode"));
            //var lstUIDMapReward = RewardCon.Instance.GetUIDMapRewardByRange(uid, GetAppsetting("CouponOwner"), GetAppsetting("CouponProgram"));
            var lstUIDMapReward = RewardCon.Instance.GetUIDMapRewardByRange(uid);
            if (lstUIDMapReward.RESULT_STATUS == "OK" && lstUIDMapReward.RESULT_OBJ.Count > 0)
            {
                for (int i = 0; i < lstUIDMapReward.RESULT_OBJ.Count; i++)
                {
                    var bufferItem = "<a href='#' class='d-flex py-1' data-bs-toggle='offcanvas' data-bs-target='#menu-activity-1'>" +
                                        "<div class='align-self-center'>" +
                                            "<span class='icon me-2 shadow-bg shadow-bg-xs rounded-s'>" +
                                                "<img src='" + lstUIDMapReward.RESULT_OBJ[i].RewardLogoPath + "' width='45' class='rounded-s' alt='img'></span>" +
                                        "</div>" +
                                        "<div class='align-self-center ps-1'>" +
                                            "<label class='pt-1 mb-n1' style='font-size: 14px; color: black; font-weight: 500;'>" + lstUIDMapReward.RESULT_OBJ[i].RewardTitle + "</label>" +
                                            "<p class='mb-0 font-11 opacity-70'><span class=''>" + lstUIDMapReward.RESULT_OBJ[i].RewardDesc + "</span></p>" +
                                        "</div>" +
                                        "<div class='align-self-center ms-auto text-end'>" +
                                            "<span class='btn btn-xxs gradient-green shadow-bg shadow-bg-xs' style='font-size: 28px; padding: 0px 12px;' onclick='CalPrivilege(\"" + lstUIDMapReward.RESULT_OBJ[i].RewardGUID + "\");'>" +
                                                "<i class='bi bi-ticket-detailed'></i></span>" +
                                        "</div>" +
                                    "</a>";


                    ltlRewardItem.Text += bufferItem;
                }
                pnlRewardItem.Visible = true;
                pnlRewardEmpty.Visible = false;
            }
            else
            {
                pnlRewardItem.Visible = false;
                pnlRewardEmpty.Visible = true;
            }

        }


    }
}
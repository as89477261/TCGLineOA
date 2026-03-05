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
    public partial class index_KM : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //RenderRewardHeader();
                //GetPassConditionByUID();
            }
        }

        private void GetPassConditionByUID()
        {
            var uid = CookieManager.GetEncryptCookie("lineoa", "uid", GetAppsetting("APIPartialCode"));
            var idCard = CookieManager.GetEncryptCookie("lineoa", "rIDCard", GetAppsetting("APIPartialCode"));
            txtCouponDetailRemark.Text = GetAppsetting("CouponConditionRemark");

            // get Is have Reward Code
            var lstUIDMapReward = RewardCon.Instance.GetUIDMapReward(uid, GetAppsetting("CouponOwner"), GetAppsetting("CouponProgram"));
            if (lstUIDMapReward.RESULT_STATUS == "OK" && lstUIDMapReward.RESULT_OBJ.Count <= 0)
            {
                var isHaveActivityWithTCG = false;
                var bufferCondition = RewardCon.Instance.GetUIDPassRewardCondition(uid, GetAppsetting("CouponPassCondition"));
                if (bufferCondition.RESULT_STATUS == "OK")
                {
                    if (bufferCondition.RESULT_OBJ.isHC != 0)
                    {
                        isHaveActivityWithTCG = true;
                    }
                    else if (bufferCondition.RESULT_OBJ.isSubTypeInfo != 0)
                    {
                        isHaveActivityWithTCG = true;
                    }
                    else if (string.IsNullOrEmpty(bufferCondition.RESULT_OBJ.isEnroll) == false)
                    {
                        isHaveActivityWithTCG = true;
                    }
                    else if (string.IsNullOrEmpty(bufferCondition.RESULT_OBJ.isFACenter) == false)
                    {
                        isHaveActivityWithTCG = true;
                    }
                    else if (string.IsNullOrEmpty(bufferCondition.RESULT_OBJ.is3Color) == false)
                    {
                        isHaveActivityWithTCG = true;
                    }

                    if (isHaveActivityWithTCG)
                    {
                        // Insert Reward for user
                        UIDMapRewardPT(uid);
                        // Render Reward Panel
                        RenderReward(uid);
                    }
                    else
                    {
                        pnlRewardItem.Visible = false;
                        pnlRewardEmpty.Visible = true;
                    }
                }
                else
                {
                    // Render Reward Panel
                    RenderReward(uid);

                }
            }
            else
            {
                // Render Reward Panel
                RenderReward(uid);

            }
        }
        private void UIDMapRewardPT(string uid)
        {
            var GetTopReward = RewardCon.Instance.GetRewardByOwner(GetAppsetting("CouponOwner"), GetAppsetting("CouponProgram"));
            if (GetTopReward.RESULT_STATUS == "OK")
            {
                var obj = new RewardMapUIDModel()
                {
                    UID = uid,
                    MatchCondition = "",
                    RewardGUID = GetTopReward.RESULT_OBJ.RewardGUID,
                    StartDate = GetTopReward.RESULT_OBJ.StartDate,
                    EndDate = GetTopReward.RESULT_OBJ.EndDate
                };
                var result = RewardCon.Instance.InsertUIDMapReward(obj);
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
                                            "<h5 class='pt-1 mb-n1'>" + lstRewardHeader.RESULT_OBJ[i].TitleProgram + "</h5>" +
                                            "<p class='mb-0 font-11 opacity-70'>" + lstRewardHeader.RESULT_OBJ[i].DescriptionProgram + "</p>" +
                                       "</div>" +
                                        "<div class='align-self-center ms-auto text-end' onclick='ShowCondition(\"" + lstRewardHeader.RESULT_OBJ[i].RewardOwnerCode + "\");'>" +
                                            "<span class='btn btn-xxs gradient-blue shadow-bg shadow-bg-xs'>เงื่อนไข</span>" +
                                        "</div>" +
                                    "</a>";

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
        private void RenderReward(string uid)
        {
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
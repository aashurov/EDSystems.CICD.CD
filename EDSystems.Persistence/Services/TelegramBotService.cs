using EDSystems.Application.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace EDSystems.Persistence.Services
{
    public class TelegramBotService : ITelegramBotService
    {
        private readonly IConfiguration _configuration;

        [Inject]
        private IWebHostEnvironment hostingEnvironment { get; set; }

        public TelegramBotService(IConfiguration configuration) => _configuration = configuration;

        //private async Task SendMessage(Parcel parcel)
        //{
        //    var bot = new TelegramBotClient(_configuration.GetValue<string>("TokenMT"));
        //    string chatId = _configuration.GetValue<string>("ChatIdMT");

        //    if (parcel.SenderBranchId == 1 && parcel.RecepientBranchId == 2 && parcel.PlanId != "16")
        //    {
        //        //Moscow Tashkent
        //        bot = new TelegramBotClient(_configuration.GetValue<string>("TokenMT"));
        //        chatId = _configuration.GetValue<string>("ChatIdMT");
        //    }
        //    else if (parcel.SenderBranchId == 1 && parcel.RecepientBranchId == 2 && parcel.PlanId == "16")
        //    {
        //        //Moscow Tashkent AVTO
        //        bot = new TelegramBotClient(_configuration.GetValue<string>("TokenAMT"));
        //        chatId = _configuration.GetValue<string>("ChatIdAMT");
        //    }
        //    else if (parcel.SenderBranchId == 2 && parcel.RecepientBranchId == 1 && parcelMain.PlanId != "16")
        //    {
        //        //Tashkent Moscow
        //        bot = new TelegramBotClient(_configuration.GetValue<string>("TokenTM"));
        //        chatId = _configuration.GetValue<string>("ChatIdTM");
        //    }
        //    else if (parcel.SenderBranchId == 1 && parcel.RecepientBranchId == 5 && parcel.PlanId != "16")
        //    {
        //        //Moscow Bishkek
        //        bot = new TelegramBotClient(_configuration.GetValue<string>("TokenMB"));
        //        chatId = _configuration.GetValue<string>("ChatIdMB");
        //    }
        //    else if (parcel.SenderBranchId == 5 && parcel.RecepientBranchId == 1 && parcel.PlanId != "16")
        //    {
        //        //Bishkek Moscow
        //        bot = new TelegramBotClient(_configuration.GetValue<string>("TokenBM"));
        //        chatId = _configuration.GetValue<string>("ChatIdBM");
        //    }
        //    string Header = "-----НОВАЯ ПОСЫЛКА-----";
        //    string Parcelnumber = "\nНомер посылки: " + "#" + parcel.Code;
        //    string senderFnameLname = "";
        //    string recepientFnameLname = "";
        //    bool roleSender = await getUserRole(parcel.SenderId);
        //    bool roleRecepient = await getUserRole(parcel.RecepientId);
        //    if (roleSender)
        //    {
        //        senderFnameLname = "\nОтправитель: " + _UserManager.FindByIdAsync(parcel.SenderId).Result.FirstName;
        //    }
        //    else
        //    {
        //        senderFnameLname = "\nОтправитель: " + "#RZ" + _UserManager.FindByIdAsync(parcel.SenderId).Result.UniqId + " " + _UserManager.FindByIdAsync(parcel.SenderId).Result?.FirstName + " " + _UserManager.FindByIdAsync(parcel.SenderId).Result?.LastName + " " + _UserManager.FindByIdAsync(parcel.SenderId).Result?.PhoneNumber;
        //    }
        //    if (roleRecepient)
        //    {
        //        recepientFnameLname = "\nПолучатель: " + _UserManager.FindByIdAsync(parcel.RecepientId).Result.FirstName;
        //    }
        //    else
        //    {
        //        recepientFnameLname = "\nПолучатель: " + "#RZ" + _UserManager.FindByIdAsync(parcel.RecepientId).Result.UniqId + " " + _UserManager.FindByIdAsync(parcel.RecepientId).Result?.FirstName + " " + _UserManager.FindByIdAsync(parcel.RecepientId).Result?.LastName + " " + _UserManager.FindByIdAsync(parce.RecepientId).Result?.PhoneNumber;
        //    }
        //    string CostState_CostDeliveryToBranch = parcel.CostState_CostDeliveryToBranch ? " Оплачено" : " Не оплачено";
        //    string CostState_CostDeliveryToPoint = parcel.CostState_CostDeliveryToPoint ? " Оплачено" : " Не оплачено";
        //    string CostState_CostPickingUp = parcel.CostState_CostPickingUp ? " Оплачено" : " Не оплачено";
        //    string CostPickingUpUSD = null;
        //    string CostDeliveryToPointUSD = null;
        //    string CostDeliveryToBranchUSD = null;

        //    if (parcel.CostPickingUpUSD > 0)
        //    { CostPickingUpUSD = "\nСтоимость Забора ($): " + parcel.CostPickingUpUSD + CostState_CostPickingUp; }
        //    if (parcel.CostDeliveryToPointUSD > 0)
        //    {
        //        CostDeliveryToPointUSD = "\nСтоимость доставки (Опл Допл) ($): " + parcel.CostDeliveryToPointUSD + CostState_CostDeliveryToPoint;
        //    }
        //    if (parcel.CostDeliveryToBranchUSD > 0)
        //    {
        //        CostDeliveryToBranchUSD = "\nСтоимость перевозки ($): " + parcel.CostDeliveryToBranchUSD + CostState_CostDeliveryToBranch;
        //    }

        //    string Weight = "\nВес посылки (кг): " + parcel.Weight;
        //    string NumberOfPointStr = "\nКоличество Мест (шт): " + parcel.NumberOfPoint;
        //    string Description = "\nОписание: " + parcel.Description;
        //    string DateCreated = "\nДата: " + parcel.DateCreated.ToString("dd.MM.yyyy");
        //    string PlanName = "\nТариф: " + PlanUseCase.ExecuteGetPlanById(int.Parse(parcel.PlanId)).Name;
        //    string Status = "\nСтатус: " + StatusUseCase.ExecuteGetStatusById(parcel.ParcelStatus.Where(s => s.IsCurrent == true).FirstOrDefault().StatusId).Name;
        //    string dd = Navigator.BaseUri;

        //    string mainText = String.Concat(
        //                                    Header,
        //                                    Parcelnumber,
        //                                    recepientFnameLname,
        //                                    senderFnameLname,
        //                                    PlanName,
        //                                    CostPickingUpUSD,
        //                                    CostDeliveryToBranchUSD,
        //                                    CostDeliveryToPointUSD,
        //                                    Weight,
        //                                    NumberOfPointStr,
        //                                    Description,
        //                                    Status,
        //                                    DateCreated);
        //    IAlbumInputMedia[] _IAlbumInputMedia;

        //    if (photolist.Count() == 0)
        //    {
        //        _IAlbumInputMedia = new IAlbumInputMedia[3];
        //        for (int i = 0; i < _IAlbumInputMedia.Length; i++)
        //        {
        //            if (i == 0)
        //            {
        //                _IAlbumInputMedia[i] = new InputMediaPhoto("https://ethno.tk/ParcelImages/noimage.png") { Caption = mainText, ParseMode = ParseMode.Markdown };
        //            }
        //            else
        //            {
        //                _IAlbumInputMedia[i] = new InputMediaPhoto("https://ethno.tk/ParcelImages/noimage.png");
        //            }
        //        }
        //    }
        //    else
        //    {
        //        _IAlbumInputMedia = new IAlbumInputMedia[photolist.Count()];
        //        for (int i = 0; i < _IAlbumInputMedia.Length; i++)
        //        {
        //            if (i == 0)
        //            {
        //                if (hostingEnvironment.IsDevelopment())
        //                {
        //                    _IAlbumInputMedia[i] = new InputMediaPhoto("https://ethno.tk/ParcelImages/" + "RZ85664276_6432.jpg") { Caption = mainText, ParseMode = ParseMode.Markdown };
        //                }
        //                else
        //                {
        //                    _IAlbumInputMedia[i] = new InputMediaPhoto("https://ethno.tk/ParcelImages/" + photolist[i]) { Caption = mainText, ParseMode = ParseMode.Markdown };
        //                }
        //            }
        //            else
        //            {
        //                if (hostingEnvironment.IsDevelopment())
        //                {
        //                    _IAlbumInputMedia[i] = new InputMediaPhoto("https://ethno.tk/ParcelImages/" + "RZ85664276_6432.jpg");
        //                }
        //                else
        //                {
        //                    _IAlbumInputMedia[i] = new InputMediaPhoto("https://ethno.tk/ParcelImages/" + photolist[i]);
        //                }
        //            }
        //        }
        //    }

        //    var cancellationToken = new CancellationToken();
        //    try
        //    {
        //        await bot.SendMediaGroupAsync(chatId: chatId, media: _IAlbumInputMedia, cancellationToken: cancellationToken);
        //        Array.Clear(_IAlbumInputMedia, 0, _IAlbumInputMedia.Length);
        //    }
        //    catch (Exception exc)
        //    {
        //        byte[] bytes = Encoding.Default.GetBytes(exc.Message);
        //        string utf8_String = Encoding.UTF8.GetString(bytes);
        //        throw;
        //    }
        //}
    }
}
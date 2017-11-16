using MeetingManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MeetingManagementSystem.DAL
{
    public static class MeetingDAL
    {
        private static MeetingContext db = new MeetingContext();

        public static bool CreateMeeting(MeetingModel createModel)
        {
            using (var ctx = new MeetingContext())
            {
                tbMeeting meetingModel = ConvertToDTO(createModel);
                ctx.tbMeetings.Add(meetingModel);
                ctx.SaveChanges();

                foreach (var item in createModel.MeetingItems)
                {
                    tbmeetingTypeItem meetingItemdto = new tbmeetingTypeItem();
                    meetingItemdto.MeetingItemId = item.MeetingItemId;
                    meetingItemdto.MeetingTypeId = meetingModel.MeetingTypeId;
                    meetingItemdto.MeetingId = meetingModel.MeetingId;
                    ctx.tbmeetingTypeItems.Add(meetingItemdto);
                    ctx.SaveChanges();
                }

                return true;
            }
        }

        private static tbMeeting ConvertToDTO(MeetingModel createModel)
        {
            return new tbMeeting()
            {
                MeetingDate = createModel.MeetingDate,
                MeetingName = createModel.MeetingName,
                MeetingId = Guid.NewGuid(),
                MeetingTime = createModel.MeetingTime,
                MeetingTypeId = createModel.MeetingTypeId
            };
        }

        public static List<MeetingItemModel> GetMeetingItemsByMeetingTypeId(Guid meetingTyeId, Guid meetingId)
        {
            using (var ctx = new MeetingContext())
            {
                List<MeetingItemModel> meetingItems = new List<MeetingItemModel>();
                List<tbmeetingTypeItem> meetingItemsDTO = ctx.tbmeetingTypeItems.AsNoTracking().Where(c => c.MeetingTypeId == meetingTyeId && c.MeetingId == meetingId).ToList();
                return meetingItems = ConvertToMeetingItemModel(meetingItemsDTO);
            }
        }

        internal static List<MeetingTypeModel> GetMeetingTypesByMeetingId(Guid meetingId)
        {
            using (var ctx = new MeetingContext())
            {
                List<MeetingTypeModel> meetingTypes = new List<MeetingTypeModel>();
                Guid meetingTypeId = ctx.tbmeetingTypeItems.AsNoTracking().Where(c => c.MeetingId == meetingId).FirstOrDefault().MeetingTypeId;
                meetingTypes = ReturnMeetingTypes(meetingTypeId);
                return meetingTypes;
            }
        }

        private static List<MeetingTypeModel> ReturnMeetingTypes(Guid meetingTypeId)
        {
            using (var ctx = new MeetingContext())
            {
                List<MeetingTypeModel> meetingTypes = new List<MeetingTypeModel>();
                List<tbMeetingType> meetingTypesdto = ctx.tbMeetingTypes.AsNoTracking().Where(c => c.MeetingTypeId == meetingTypeId).ToList();
                meetingTypes = ConvertToMeetingTypeModel(meetingTypesdto);
                return meetingTypes;
            }
        }

        public static List<MeetingModel> GetMeetings()
        {
            using (var ctx = new MeetingContext())
            {
                var meetingsdto = ctx.tbMeetings.ToList();
                List<MeetingModel> meetings = ConvertToMeetingModel(meetingsdto);
                return meetings;
            }

        }

        public static List<MeetingTypeModel> GetMeetingTypes()
        {
            using (var ctx = new MeetingContext())
            {
                List<MeetingTypeModel> meetingTypes = new List<MeetingTypeModel>();
                var meetingTypestdo = ctx.tbMeetingTypes.AsNoTracking().ToList();
                meetingTypes = ConvertToMeetingTypeModel(meetingTypestdo);
                return meetingTypes;
            }
        }

        public static List<StatusModel> GetStatuses()
        {
            using (var ctx = new MeetingContext())
            {
                List<StatusModel> statuses = new List<StatusModel>();
                var statusestdo = ctx.tbStatus.AsNoTracking().ToList();
                statuses = ConvertToStatus(statusestdo);
                return statuses;
            }
        }

        public static bool UpdateMeetingItemStatus(MeetingModel updateMeetingItemStatus)
        {
            using (var ctx = new MeetingContext())
            {
                MeetingItemModel itemModel = new MeetingItemModel();
                tbMeetingItem meetingItemdto = ConvertToMeetingItemDTO(updateMeetingItemStatus);

                ctx.Entry(meetingItemdto).State = EntityState.Modified;

                try
                {
                    ctx.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return true;
                }
            }
        }

        private static tbMeetingItem ConvertToMeetingItemDTO(MeetingModel updateMeetingItemStatus)
        {
            tbMeetingItem meetingItem = new tbMeetingItem();
            //tbMeetingType meetingType = new tbMeetingType();
            //meetingType = db.tbMeetingTypes.Find(updateMeetingItemStatus.MeetingTypeId);
            meetingItem.MeetingItemStatusId = updateMeetingItemStatus.MeetingItems.FirstOrDefault().MeetingItemStatusId;
            meetingItem.MeetingItemName = updateMeetingItemStatus.MeetingItems.FirstOrDefault().MeetingItemName;
            meetingItem.PersonAssigned = updateMeetingItemStatus.MeetingItems.FirstOrDefault().PersonAssigned;
            meetingItem.MeetingItemId = updateMeetingItemStatus.MeetingItems.FirstOrDefault().MeetingItemId;
            return meetingItem;

        }

        private static List<StatusModel> ConvertToStatus(List<tbStatu> statusestdo)
        {
            List<StatusModel> newStatuses = new List<StatusModel>();
            foreach (var status in statusestdo)
            {
                newStatuses.Add(new StatusModel()
                {
                    StatusId = status.StatusId,
                    StatusName = status.StatusName,
                });
            }
            return newStatuses;
        }

        private static List<MeetingTypeModel> ConvertToMeetingTypeModel(List<tbMeetingType> meetingTypes)
        {
            List<MeetingTypeModel> newMeetingTypes = new List<MeetingTypeModel>();
            foreach (var meetingTypedto in meetingTypes)
            {
                newMeetingTypes.Add(new MeetingTypeModel()
                {
                    MeetingTypeCode = meetingTypedto.MeetingTypeCode,
                    MeetingTypeName = meetingTypedto.MeetingTypeName,
                    MeetingTypeId = meetingTypedto.MeetingTypeId
                });
            }
            return newMeetingTypes;
        }

        private static List<MeetingModel> ConvertToMeetingModel(List<tbMeeting> meetingsdto)
        {
            using (var ctx = new MeetingContext())
            {
                List<MeetingModel> meetings = new List<MeetingModel>();
                foreach (var meetingdto in meetingsdto)
                {
                    tbMeetingType meetingType = db.tbMeetingTypes.Find(meetingdto.MeetingTypeId);
                    meetings.Add(new MeetingModel()
                    {
                        MeetingDate = meetingdto.MeetingDate,
                        MeetingId = meetingdto.MeetingId,
                        MeetingTime = meetingdto.MeetingTime,
                        MeetingTypeId = meetingdto.MeetingTypeId,
                        MeetingName = meetingdto.MeetingName,
                        MeetingTypeName = ctx.tbMeetingTypes.AsNoTracking().Where(c => c.MeetingTypeId == meetingdto.MeetingTypeId).FirstOrDefault().MeetingTypeName,
                    });
                }
                return meetings;
            }
        }

        private static List<MeetingItemModel> ConvertToMeetingItemModel(List<tbmeetingTypeItem> meetingItemsDTO)
        {
            using (var ctx = new MeetingContext())
            {
                List<MeetingItemModel> meetingItems = new List<MeetingItemModel>();
                foreach (var meetingItemdto in meetingItemsDTO)
                {
                    var statusId = ctx.tbMeetingItems.AsNoTracking().FirstOrDefault(c => c.MeetingItemId == meetingItemdto.MeetingItemId).MeetingItemStatusId;
                    var statusName = ctx.tbStatus.AsNoTracking().Where(c => c.StatusId == statusId).FirstOrDefault().StatusName;
                    meetingItems.Add(new MeetingItemModel()
                    {
                        MeetingItemId = meetingItemdto.MeetingItemId,
                        MeetingItemName = ctx.tbMeetingItems.AsNoTracking().FirstOrDefault(c => c.MeetingItemId == meetingItemdto.MeetingItemId).MeetingItemName,
                        MeetingItemStatusId = ctx.tbMeetingItems.AsNoTracking().FirstOrDefault(c => c.MeetingItemId == meetingItemdto.MeetingItemId).MeetingItemStatusId,
                        MeetingItemStatusName = statusName,
                        PersonAssigned = ctx.tbMeetingItems.AsNoTracking().FirstOrDefault(c => c.MeetingItemId == meetingItemdto.MeetingItemId).PersonAssigned,
                    });
                }

                return meetingItems;
            }
        }
    }
}
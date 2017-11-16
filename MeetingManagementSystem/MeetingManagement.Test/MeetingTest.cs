using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MeetingManagementSystem.Models;
using System.Collections.Generic;
using MeetingManagementSystem.Services;

namespace MeetingManagement.Test
{
    [TestClass]
    public class MeetingTest
    {
        [TestMethod]
        public void GetMeetingTypes_ShouldReturnMeeting()
        {
            List<MeetingTypeModel> meetingTypes = new List<MeetingTypeModel>();

            var meetingServiceP = new MeetingServiceProvider();
            meetingTypes = meetingServiceP.GetMeetingTypes();
            if (meetingTypes.Count > 0)
            {
                Assert.AreNotSame(0, 1);
            }else
            {
                Assert.Fail();
            }

        }
    }
}

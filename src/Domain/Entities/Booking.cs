using System;
using System.Collections.Generic;
using System.Text;

namespace Alkonof_Backend.Domain.Entities;

public class Booking
{
   
    private Booking(int id, int responsibalId, string statuse, string title, 
        string location, DateTimeOffset expiredAt, int customerAnser, int responsiplAnser)
    {
        Id = id;
        ResponsibalId = responsibalId;
        Statuse = statuse;
        Title = title;
        Location = location;
        ExpiredAt = expiredAt;
        CustomerAnser = customerAnser;
        ResponsiplAnser = responsiplAnser;
    }

    public int Id { get; set; }
    public int ResponsibalId {  get; set; }
    public string Statuse {  get; set; }
    public string Title {  get; set; }
    public string Location {  get; set; }
    public DateTimeOffset ExpiredAt {  get; set; }
    public int CustomerAnser {  get; set; }
    public int ResponsiplAnser {  get; set; }


    //relationals
    public List<Contract>?Contracts { get; set; }
    public List<PrepareMeeting>?PrepareMeetings { get; set; }

    public enum enBokingStatus
    {
        Created=0,
        InReviewCustomer=1,
        InReviewResponsibal=2,
        Confirmed=3,
        Cancelled=4,
        Expired=5,
        Delied=6
    }
    public enum enDecision
    {
        Approved=0,
        Rejected=1,
        Pending=2,
        Dely=3
    }
    public enum enPrepare
    {
        Temporary=0,
        Confirmed=1
    }

}

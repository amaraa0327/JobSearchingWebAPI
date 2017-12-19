using JobSearchTrackingService.Models;
using JobSearchTrackingService.EntityDM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JobSearchTrackingService.Controllers
{
    public class JSTrackingController : ApiController
    {
        public IHttpActionResult GetAllTracking()
        {
            IList<JSTrackingViewModel> jstModels = null;

            using (var ctx = new JobSearchTrackingEntities())
            {
                jstModels = ctx.JSTrackings.Include("Company").Include("Location").Include("Contact")
                    .Include("FollowUp1").Include("FollowUp2").Select(jst => new JSTrackingViewModel()
                    {
                        JSTrackingID = jst.JSTrackingID,
                        Company = jst.Company == null ? null : new CompanyViewModel()
                        {
                            CompanyID = jst.Company.CompanyID,
                            Name = jst.Company.Name,
                            Website = jst.Company.Website
                        },
                        Location = jst.Location == null ? null : new LocationViewModel()
                        {
                            LocationID = jst.Location.LocationID,
                            Description = jst.Location.Description
                        },
                        JobDescription = jst.JobDescription,
                        SourcePosting = jst.SourcePosting,
                        Contact = jst.Contact == null ? null : new ContactViewModel()
                        {
                            ContactD = jst.Contact.ContactID,
                            Name = jst.Contact.ContactName,
                            EmailAddress = jst.Contact.Email,
                            PhoneNumber = jst.Contact.Phone
                        },
                        ResumeDate = jst.ResumeDate,
                        FollowUp1 = jst.FollowUp1 == null ? null : new FollowUp1ViewModel()
                        {
                            JSTrackingID = jst.FollowUp1.JSTrackingID,
                            Type = jst.FollowUp1.Type,
                            FollowUpDate = jst.FollowUp1.FollowDate
                        },
                        FollowUp2 = jst.FollowUp2 == null ? null : new FollowUp2ViewModel()
                        {
                            JSTrackingID = jst.FollowUp2.JSTrackingID,
                            Type = jst.FollowUp2.Type,
                            FollowUpDate = jst.FollowUp2.FollowUpDate
                        },
                        InterviewDateTime = jst.InterviewDate,
                        Note = jst.Note
                    }).ToList<JSTrackingViewModel>();
            }

            if (jstModels.Count == 0)
                return NotFound();

            return Ok(jstModels);
        }

        public IHttpActionResult GetAllTracking(int id)
        {
            JSTrackingViewModel jstModel = null;

            using (var ctx = new JobSearchTrackingEntities())
            {
                jstModel = ctx.JSTrackings.Include("Company").Include("Location").Include("Contact")
                    .Include("FollowUp1").Include("FollowUp2").Where(jst => jst.JSTrackingID == id).Select(jst => new JSTrackingViewModel()
                    {
                        JSTrackingID = jst.JSTrackingID,
                        Company = jst.Company == null ? null : new CompanyViewModel()
                        {
                            CompanyID = jst.Company.CompanyID,
                            Name = jst.Company.Name,
                            Website = jst.Company.Website
                        },
                        Location = jst.Location == null ? null : new LocationViewModel()
                        {
                            LocationID = jst.Location.LocationID,
                            Description = jst.Location.Description
                        },
                        JobDescription = jst.JobDescription,
                        SourcePosting = jst.SourcePosting,
                        Contact = jst.Contact == null ? null : new ContactViewModel()
                        {
                            ContactD = jst.Contact.ContactID,
                            Name = jst.Contact.ContactName,
                            EmailAddress = jst.Contact.Email,
                            PhoneNumber = jst.Contact.Phone
                        },
                        ResumeDate = jst.ResumeDate,
                        FollowUp1 = jst.FollowUp1 == null ? null : new FollowUp1ViewModel()
                        {
                            JSTrackingID = jst.FollowUp1.JSTrackingID,
                            Type = jst.FollowUp1.Type,
                            FollowUpDate = jst.FollowUp1.FollowDate
                        },
                        FollowUp2 = jst.FollowUp2 == null ? null : new FollowUp2ViewModel()
                        {
                            JSTrackingID = jst.FollowUp2.JSTrackingID,
                            Type = jst.FollowUp2.Type,
                            FollowUpDate = jst.FollowUp2.FollowUpDate
                        },
                        InterviewDateTime = jst.InterviewDate,
                        Note = jst.Note
                    }).FirstOrDefault<JSTrackingViewModel>();
            }

            if (jstModel == null)
                return NotFound();

            return Ok(jstModel);
        }

        public IHttpActionResult GetFollowed(bool followUp)
        {
            IList<JSTrackingViewModel> jstModels = null;

            using (var ctx = new JobSearchTrackingEntities())
            {
                jstModels = ctx.JSTrackings.Include("Company").Include("Location").Include("Contact")
                    .Include("FollowUp1").Include("FollowUp2").Where(jst => followUp ? (jst.FollowUp1 != null || jst.FollowUp2 != null) : (jst.FollowUp1 == null && jst.FollowUp2 == null)).Select(jst => new JSTrackingViewModel()
                    {
                        JSTrackingID = jst.JSTrackingID,
                        Company = jst.Company == null ? null : new CompanyViewModel()
                        {
                            CompanyID = jst.Company.CompanyID,
                            Name = jst.Company.Name,
                            Website = jst.Company.Website
                        },
                        Location = jst.Location == null ? null : new LocationViewModel()
                        {
                            LocationID = jst.Location.LocationID,
                            Description = jst.Location.Description
                        },
                        JobDescription = jst.JobDescription,
                        SourcePosting = jst.SourcePosting,
                        Contact = jst.Contact == null ? null : new ContactViewModel()
                        {
                            ContactD = jst.Contact.ContactID,
                            Name = jst.Contact.ContactName,
                            EmailAddress = jst.Contact.Email,
                            PhoneNumber = jst.Contact.Phone
                        },
                        ResumeDate = jst.ResumeDate,
                        FollowUp1 = jst.FollowUp1 == null ? null : new FollowUp1ViewModel()
                        {
                            JSTrackingID = jst.FollowUp1.JSTrackingID,
                            Type = jst.FollowUp1.Type,
                            FollowUpDate = jst.FollowUp1.FollowDate
                        },
                        FollowUp2 = jst.FollowUp2 == null ? null : new FollowUp2ViewModel()
                        {
                            JSTrackingID = jst.FollowUp2.JSTrackingID,
                            Type = jst.FollowUp2.Type,
                            FollowUpDate = jst.FollowUp2.FollowUpDate
                        },
                        InterviewDateTime = jst.InterviewDate,
                        Note = jst.Note
                    }).ToList<JSTrackingViewModel>();
            }

            if (jstModels.Count == 0)
                return NotFound();

            return Ok(jstModels);
        }

        public IHttpActionResult GetInterview(bool withinterview)
        {
            IList<JSTrackingViewModel> jstModels = null;

            using (var ctx = new JobSearchTrackingEntities())
            {
                jstModels = ctx.JSTrackings.Include("Company").Include("Location").Include("Contact")
                    .Include("FollowUp1").Include("FollowUp2").Where(jst => withinterview ? (jst.InterviewDate != null) : (jst.InterviewDate == null)).Select(jst => new JSTrackingViewModel()
                    {
                        JSTrackingID = jst.JSTrackingID,
                        Company = jst.Company == null ? null : new CompanyViewModel()
                        {
                            CompanyID = jst.Company.CompanyID,
                            Name = jst.Company.Name,
                            Website = jst.Company.Website
                        },
                        Location = jst.Location == null ? null : new LocationViewModel()
                        {
                            LocationID = jst.Location.LocationID,
                            Description = jst.Location.Description
                        },
                        JobDescription = jst.JobDescription,
                        SourcePosting = jst.SourcePosting,
                        Contact = jst.Contact == null ? null : new ContactViewModel()
                        {
                            ContactD = jst.Contact.ContactID,
                            Name = jst.Contact.ContactName,
                            EmailAddress = jst.Contact.Email,
                            PhoneNumber = jst.Contact.Phone
                        },
                        ResumeDate = jst.ResumeDate,
                        FollowUp1 = jst.FollowUp1 == null ? null : new FollowUp1ViewModel()
                        {
                            JSTrackingID = jst.FollowUp1.JSTrackingID,
                            Type = jst.FollowUp1.Type,
                            FollowUpDate = jst.FollowUp1.FollowDate
                        },
                        FollowUp2 = jst.FollowUp2 == null ? null : new FollowUp2ViewModel()
                        {
                            JSTrackingID = jst.FollowUp2.JSTrackingID,
                            Type = jst.FollowUp2.Type,
                            FollowUpDate = jst.FollowUp2.FollowUpDate
                        },
                        InterviewDateTime = jst.InterviewDate,
                        Note = jst.Note
                    }).ToList<JSTrackingViewModel>();
            }

            if (jstModels.Count == 0)
                return NotFound();

            return Ok(jstModels);
        }

        public IHttpActionResult PostJSTracking(JSTrackingViewModel jstracking)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");
            using (var ctx = new JobSearchTrackingEntities())
            {
                Company company = jstracking.Company == null ? null : ctx.Companies.Where(c => c.Name == jstracking.Company.Name).FirstOrDefault();

                if (company == null)
                    company = jstracking.Company == null ? null : new Company()
                    {
                        CompanyID = 0,
                        Name = jstracking.Company.Name,
                        Website = jstracking.Company.Website
                    };
                else
                {
                    company.Website = jstracking.Company.Website;
                }

                Contact contact = jstracking.Contact == null ? null : ctx.Contacts.Where(c => c.Email == jstracking.Contact.EmailAddress).FirstOrDefault();

                if (contact == null)
                    contact = jstracking.Contact == null ? null : new Contact()
                    {
                        ContactID = 0,
                        Company = company,
                        ContactName = jstracking.Contact.Name,
                        Email = jstracking.Contact.EmailAddress,
                        Phone = jstracking.Contact.PhoneNumber,
                    };
                else
                {
                    contact.ContactName = jstracking.Contact.Name;
                    contact.Company = company;
                    contact.Email = jstracking.Contact.EmailAddress;
                    contact.Phone = jstracking.Contact.PhoneNumber;
                }

                Location location = jstracking.Location == null ? null : ctx.Locations.Where(l => l.Description == jstracking.Location.Description).FirstOrDefault();

                if (location == null)
                    location = jstracking.Location == null ? null : new Location()
                    {
                        LocationID = 0,
                        Description = jstracking.Location.Description
                    };
                else
                {
                    location.Description = jstracking.Location.Description;
                }


                ctx.JSTrackings.Add(new JSTracking()
                {
                    Company = company,
                    Contact = contact,
                    FollowUp1 = jstracking.FollowUp1 == null ? null : new FollowUp1()
                    {
                        Type = jstracking.FollowUp1.Type,
                        FollowDate = jstracking.FollowUp1.FollowUpDate
                    },
                    FollowUp2 = jstracking.FollowUp2 == null ? null : new FollowUp2()
                    {
                        Type = jstracking.FollowUp2.Type,
                        FollowUpDate = jstracking.FollowUp2.FollowUpDate
                    },
                    InterviewDate = jstracking.InterviewDateTime,
                    JobDescription = jstracking.JobDescription,
                    Location = location,
                    Note = jstracking.Note,
                    ResumeDate = jstracking.ResumeDate,
                    SourcePosting = jstracking.SourcePosting
                });
                ctx.SaveChanges();
            }

            return Ok();
        }

        public IHttpActionResult Put(JSTrackingViewModel jstracking)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            using (var ctx = new JobSearchTrackingEntities())
            {
                var existingjstracking = ctx.JSTrackings.Where(s => s.JSTrackingID == jstracking.JSTrackingID)
                                                        .FirstOrDefault<JSTracking>();

                Company company = jstracking.Company == null ? null : ctx.Companies.Where(c => c.Name == jstracking.Company.Name).FirstOrDefault();

                if (company == null)
                    company = jstracking.Company == null ? null : new Company()
                    {
                        CompanyID = 0,
                        Name = jstracking.Company.Name,
                        Website = jstracking.Company.Website
                    };
                else
                {
                    company.Website = jstracking.Company.Website;
                }

                Contact contact = jstracking.Contact == null ? null : ctx.Contacts.Where(c => c.Email == jstracking.Contact.EmailAddress).FirstOrDefault();

                if (contact == null)
                    contact = jstracking.Contact == null ? null : new Contact()
                    {
                        ContactID = 0,
                        Company = company,
                        ContactName = jstracking.Contact.Name,
                        Email = jstracking.Contact.EmailAddress,
                        Phone = jstracking.Contact.PhoneNumber,
                    };
                else
                {
                    contact.ContactName = jstracking.Contact.Name;
                    contact.Company = company;
                    contact.Email = jstracking.Contact.EmailAddress;
                    contact.Phone = jstracking.Contact.PhoneNumber;
                }

                Location location = jstracking.Location == null ? null : ctx.Locations.Where(l => l.Description == jstracking.Location.Description).FirstOrDefault();

                if (location == null)
                    location = jstracking.Location == null ? null : new Location()
                    {
                        LocationID = 0,
                        Description = jstracking.Location.Description
                    };
                else
                {
                    location.Description = jstracking.Location.Description;
                }

                if (existingjstracking != null)
                {
                    existingjstracking.Company = company;
                    existingjstracking.Contact = contact;
                    existingjstracking.FollowUp1 = (jstracking.FollowUp1 == null
                        || (jstracking.FollowUp1 != null
                        && jstracking.FollowUp1.Type == null
                        && jstracking.FollowUp1.FollowUpDate == null)) ? null : new FollowUp1()
                        {
                            JSTracking = existingjstracking,
                            Type = jstracking.FollowUp1.Type,
                            FollowDate = jstracking.FollowUp1.FollowUpDate
                        };

                    if (existingjstracking.FollowUp1 != null && (jstracking.FollowUp1 != null
                        && jstracking.FollowUp1.Type == null
                        && jstracking.FollowUp1.FollowUpDate == null))
                        ctx.Entry(existingjstracking.FollowUp1).State = System.Data.Entity.EntityState.Deleted;

                    existingjstracking.FollowUp2 = (jstracking.FollowUp2 == null
                        || (jstracking.FollowUp2 != null
                        && jstracking.FollowUp2.Type == null
                        && jstracking.FollowUp2.FollowUpDate == null)) ? null : new FollowUp2()
                        {
                            JSTracking = existingjstracking,
                            Type = jstracking.FollowUp2.Type,
                            FollowUpDate = jstracking.FollowUp2.FollowUpDate
                        };

                    if (existingjstracking.FollowUp2 != null && (jstracking.FollowUp2 != null
                        && jstracking.FollowUp2.Type == null
                        && jstracking.FollowUp2.FollowUpDate == null))
                        ctx.Entry(existingjstracking.FollowUp2).State = System.Data.Entity.EntityState.Deleted;

                    existingjstracking.InterviewDate = jstracking.InterviewDateTime;
                    existingjstracking.JobDescription = jstracking.JobDescription;
                    existingjstracking.Location = location;
                    existingjstracking.Note = jstracking.Note;
                    existingjstracking.ResumeDate = jstracking.ResumeDate;
                    existingjstracking.SourcePosting = jstracking.SourcePosting;

                    ctx.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid student id");

            using (var ctx = new JobSearchTrackingEntities())
            {
                var jstracking = ctx.JSTrackings
                    .Where(jst => jst.JSTrackingID == id)
                    .FirstOrDefault();

                if (jstracking.Company != null)
                    ctx.Entry(jstracking.Company).State = System.Data.Entity.EntityState.Deleted;
                if (jstracking.Contact != null)
                    ctx.Entry(jstracking.Contact).State = System.Data.Entity.EntityState.Deleted;
                if (jstracking.FollowUp1 != null)
                    ctx.Entry(jstracking.FollowUp1).State = System.Data.Entity.EntityState.Deleted;
                if (jstracking.FollowUp2 != null)
                    ctx.Entry(jstracking.FollowUp2).State = System.Data.Entity.EntityState.Deleted;

                jstracking.Location = null;

                ctx.Entry(jstracking).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
            }

            return Ok();
        }
    }
}

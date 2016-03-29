using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using PropertyManager.API.Domain;
using PropertyManager.API.Infrastructure;
using PropertyManager.API.Models;
using AutoMapper;

namespace PropertyManager.API.Controllers
{
    [Authorize]
    public class WorkOrdersController : ApiController
    {
        private PropertyManagerDataContext db = new PropertyManagerDataContext();

        // GET: api/WorkOrders
        public IEnumerable<WorkOrderModel> GetWorkOrders()
        {
            return Mapper.Map<IEnumerable<WorkOrderModel>>(db.WorkOrders.Where(wo => wo.User.UserName == User.Identity.Name));
        }


        // GET: api/WorkOrders/5
        [ResponseType(typeof(WorkOrderModel))]
        public IHttpActionResult GetWorkOrder(int id)
        {
            WorkOrder workOrder = db.WorkOrders.FirstOrDefault(wo => wo.User.UserName == User.Identity.Name && wo.WorkOrderId == id);
            if (workOrder == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<WorkOrderModel>(workOrder));
        }

        [Route("api/workorders/highpriority")]
        public IEnumerable<WorkOrderModel> GetHigh()
        {
            var HighPriorityWorkOrders = db.WorkOrders
                                            .Where(wo => wo.User.UserName == User.Identity.Name)
                                            .Where(wo => wo.Priority == (Priorities)5);
            return Mapper.Map<IEnumerable<WorkOrderModel>>(HighPriorityWorkOrders);
        }

        // GET: api/WorkOrdersCount
        [Route("api/workorders/count")]
        public int GetWorkOrdersCount()
        {
            int count = db.WorkOrders.Where(wo => wo.User.UserName == User.Identity.Name).Count();

            return count;
        }

        // PUT: api/WorkOrders/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutWorkOrder(int id, WorkOrderModel workOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != workOrder.WorkOrderId)
            {
                return BadRequest();
            }

            var dbWorkOrder = db.WorkOrders.Find(id);

            dbWorkOrder.Update(workOrder);
            db.Entry(dbWorkOrder).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkOrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/WorkOrders
        [ResponseType(typeof(WorkOrderModel))]
        public IHttpActionResult PostWorkOrder(WorkOrderModel workOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dbWorkOrder = new WorkOrder(workOrder);
            dbWorkOrder.User = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);

            db.WorkOrders.Add(dbWorkOrder);
            db.SaveChanges();


            workOrder.WorkOrderId = dbWorkOrder.WorkOrderId;

            return CreatedAtRoute("DefaultApi", new { id = workOrder.WorkOrderId }, workOrder);
        }

        // DELETE: api/WorkOrders/5
        [ResponseType(typeof(WorkOrder))]
        public IHttpActionResult DeleteWorkOrder(int id)
        {
            WorkOrder workOrder = db.WorkOrders.Find(id);
            if (workOrder == null)
            {
                return NotFound();
            }

            db.WorkOrders.Remove(workOrder);
            db.SaveChanges();

            return Ok(Mapper.Map<WorkOrderModel>(workOrder));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WorkOrderExists(int id)
        {
            return db.WorkOrders.Count(e => e.WorkOrderId == id) > 0;
        }
    }
}
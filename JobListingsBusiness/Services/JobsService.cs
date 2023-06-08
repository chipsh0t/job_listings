using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobListingsBusiness.Services.Contracts;
using JobListingsDAL.UnitOfWork.Contracts;

namespace JobListingsBusiness.Services
{
	public class JobsService:IJobsService
	{
		private IUnitOfWork _unitOfWork;
		public JobsService(IUnitOfWork unitOfWork) { _unitOfWork = unitOfWork; }


	}
}

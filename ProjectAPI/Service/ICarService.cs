using ProjectAPI.Models;
using ProjectAPI.Sharecomponent;
using System.Collections.Generic;

namespace ProjectAPI.Service
{
    public interface ICarService
    {
        /// <summary>
        /// get list of all CAR
        /// </summary>
        /// <returns></returns>
        List<CAR> GetCARList();

        /// <summary>
        /// get CAR details by CAR id
        /// </summary>
        /// <param name="CARId"></param>
        /// <returns></returns>
        CAR GetCARDetailsById(int? CARId);

        /// <summary>
        ///  add edit CAR
        /// </summary>
        /// <param name="CARModel"></param>
        /// <returns></returns>
        ResponseModel SaveCAR(CAR CARModel);


        /// <summary>
        /// delete CAR
        /// </summary>
        /// <param name="CARId"></param>
        /// <returns></returns>
        ResponseModel DeleteCAR(int CARId);
    }
}

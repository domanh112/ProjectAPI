using Microsoft.AspNetCore.Mvc;
using ProjectAPI.Connection;
using ProjectAPI.Models;
using ProjectAPI.Sharecomponent;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectAPI.Service
{
    public class CarService : ICarService
    {
        private DataContext _context;
        public CarService(DataContext context)
        {
            _context = context;
        }

        public CAR GetCARDetailsById(int? CARId)
        {
            CAR CAR;
            try
            {
                CAR = _context.Find<CAR>(CARId);
                if (CAR?.DELETED != SMX.IsDeleted && CARId!=0)
                {
                    return CAR;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return null;

        }

        public List<CAR> GetCARList()
        {
            List<CAR> CARs;
            try
            {
                CARs = _context.Set<CAR>().ToList();
                var result = CARs.Where(x => x.DELETED == SMX.IsNotDeleted);
                return result.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ResponseModel SaveCAR(CAR CARModel)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                CAR item = GetCARDetailsById(CARModel.CAR_ID);
                if (item != null)
                {
                    item.CAR_CATEGORY_ID = CARModel.CAR_CATEGORY_ID;
                    item.CAR_NAME = CARModel.CAR_NAME;
                    item.PLATE_NUMBER = CARModel.PLATE_NUMBER;
                    item.PRICE = CARModel.PRICE;
                    item.DESCRIPTION = CARModel.DESCRIPTION;

                    _context.Update<CAR>(item);
                    model.Messsage = "CAR Update Successfully";
                }
                else
                {
                    CARModel.DELETED = SMX.IsNotDeleted;
                    CARModel.VERSION = SMX.First_Version;
                    _context.Add<CAR>(CARModel);
                    model.Messsage = "CAR Inserted Successfully";
                }
                _context.SaveChanges();
                model.IsSuccess = true;
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }
        public ResponseModel DeleteCAR(int CARId)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                CAR item = GetCARDetailsById(CARId);
                if (item != null)
                {
                    //_context.Remove<CAR>(item);
                    item.DELETED = SMX.IsDeleted;

                    _context.Update<CAR>(item);
                    _context.SaveChanges();
                    model.IsSuccess = true;
                    model.Messsage = "CAR Deleted Successfully";
                }
                else
                {
                    model.IsSuccess = false;
                    model.Messsage = "CAR Not Found";
                }
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }
    }
}

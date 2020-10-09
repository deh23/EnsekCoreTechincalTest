using System;
using System.Collections.Generic;

namespace EnsekCore.Models
{
    public class MeterReadingEngine 
    {
        private IRepository _repository;

        public MeterReadingEngine(IRepository repository)
        {
            _repository = repository;
        }

        public MeterReadingResults Parse(string lines)
        {
            var rows = lines.Split(new[] { '\n', '\r' }, StringSplitOptions.None);

            MeterReadingResults meterReadingResultsModel = new MeterReadingResults
            {
                MeterReadings = new List<MeterReadingModel>()
            };

            foreach (var row in rows)
            {
                if (row.Contains("MeterReadingDateTime") || row == "")
                {
                    continue;
                }

                var columns = row.Split(new[] { ',' }, StringSplitOptions.None);
                var meterReadingModel = new MeterReadingModel()
                {
                    AccountId = int.Parse(columns[0]),
                    MeterReadingDateTime = columns[1],
                    MeterReadValue = columns[2]
                };

                var userAccount = _repository.Get(meterReadingModel.AccountId);

                if(userAccount == null)
                {
                    meterReadingResultsModel.MeterReadings.Add(meterReadingModel);
                    meterReadingResultsModel.Failed++;
                    continue;
                }

                MeterReading meterReading = new MeterReading
                {
                    AccountId = meterReadingModel.AccountId,
                    MeterReadingDateTime = meterReadingModel.MeterReadingDateTime,
                    MeterReadValue = meterReadingModel.MeterReadValue
                };

                var added = _repository.Add(meterReading);

                meterReadingModel.Successful = added;
                meterReadingResultsModel.MeterReadings.Add(meterReadingModel);
                meterReadingResultsModel.Successful++;

            }
            return meterReadingResultsModel;
        }
    }
}

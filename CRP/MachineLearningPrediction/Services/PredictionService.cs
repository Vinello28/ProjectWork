using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineLearningPrediction.Services
{
    public class PredictionService
    {
        /// <summary>
        /// -----------------ONLY_for_DEBUG-----------------
        /// Method to predict the illness given the symptoms
        /// </summary>
        public void PredictIllnessSampleInput()
        {
            //Load sample data
            var sampleData = new IllnessPredictionEngine.ModelInput()
            {
                Symptoms = @"cough,mucus production,shortness of breath,chest pain",
                Risk_level = @"",
            };

            //Load model and predict output
            var result = IllnessPredictionEngine.Predict(sampleData);
        }

        /// <summary>
        /// Method to predict the illness given the symptoms
        /// </summary>
        /// <param name="symptoms"></param>
        public void PredictIllness(string symptoms)
        {
            //Load sample data
            var sampleData = new IllnessPredictionEngine.ModelInput()
            {
                Symptoms = symptoms,
                Risk_level = @"",
            };

            //Load model and predict output
            var result = IllnessPredictionEngine.Predict(sampleData);
        }
    }
}

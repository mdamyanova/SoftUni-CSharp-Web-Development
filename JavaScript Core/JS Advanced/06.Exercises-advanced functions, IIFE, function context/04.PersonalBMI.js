function solve (name, age, weight, height) {
    let patientCharts = {
        name: name,
        personalInfo: {
            age: age,
            weight: weight,
            height: height
        },
    };

    patientCharts.BMI = calculateBMI(patientCharts.personalInfo.weight, patientCharts.personalInfo.height);
    patientCharts.status = getBmiStatus(patientCharts.BMI);

    if (patientCharts.status === 'obese') {
        patientCharts.recommendation = 'admission required';
    }

    return patientCharts;

    function calculateBMI (mass, height) {
        let meters = height / 100.00;
        return Math.round((mass / (meters * meters)));
    }

    function getBmiStatus (bmi) {
        if (bmi < 18.5) {
            return 'underweight';
        } else if (bmi < 25) {
            return 'normal';
        } else if (bmi < 30) {
            return 'overweight';
        } else {
            return 'obese';
        }
    }
}
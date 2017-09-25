function constructionCrew(worker) {
    if (worker.handsShaking) {
        let workerWeight = worker.weight;
        let workerYearsOfExperience = worker.experience;
        let resultBloodAlchoholLevel = workerWeight * 0.1 * workerYearsOfExperience;
        worker.bloodAlcoholLevel += resultBloodAlchoholLevel;
        worker.handsShaking = false;
        return worker;
    } else {
        return worker;
    }
}
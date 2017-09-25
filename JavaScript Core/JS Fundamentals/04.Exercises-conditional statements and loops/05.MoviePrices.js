function moviePrices([title, day]) {
    if(title.toUpperCase() == "THE GODFATHER") {
        switch(day.toLowerCase()){
            case "monday":return 12;
            case "tuesday":return 10;
            case "wednesday":return 15;
            case "thursday":return 12.50;
            case "friday":return 15;
            case "saturday":return 25;
            case "sunday":return 30;
            default: return "error"
        }
    } else if(title.toUpperCase() == "SCHINDLER'S LIST"){
        switch(day.toLowerCase()){
            case "monday":
            case "tuesday":
            case "wednesday":
            case "thursday":
            case "friday":
                return 8.50;
            case "saturday":
            case "sunday":
                return 15;
            default: return "error"
        }
    } else if(title.toUpperCase() == "CASABLANCA"){
        switch(day.toLowerCase()){
            case "monday":
            case "tuesday":
            case "wednesday":
            case "thursday":
            case "friday":
                return 8;
            case "saturday":
            case "sunday":
                return 10;
            default: return "error"
        }
    } else if(title.toUpperCase() == "THE WIZARD OF OZ"){
        switch(day.toLowerCase()){
            case "monday":
            case "tuesday":
            case "wednesday":
            case "thursday":
            case "friday":
                return 10;
            case "saturday":
            case "sunday":
                return 15;
            default: return "error"
        }
    } else {
        return "error"
    }
}
function calendar([day, month, year])
{
    month--;
    let days = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];

    //checks if it's leap year
    if (((year % 4 == 0) && (year % 100 != 0)) || (year % 400 == 0))
        days[1] = 29;

    let html = '<table>\n';
    html += '  <tr><th>Sun</th><th>Mon</th><th>Tue</th><th>Wed</th><th>Thu</th><th>Fri</th><th>Sat</th></tr>\n';

    //previous month
    let week = 0;
    let date = new Date(year, month, 1);
    let dayOfWeek = date.getDay();
    let firstDayPrevMonth = days[(month-1 + 12) % 12]-dayOfWeek;

    if (dayOfWeek > 0)
        html += '  <tr>';

    for (let i=1; i<=dayOfWeek; i++) {
        html += '<td class="prev-month">' + (firstDayPrevMonth + i) + '</td>';
        week++;
    }

    //current month
    let monthDaysCount = days[month];
    for (let i=1; i<=monthDaysCount; i++) {
        if (week == 0)
            html += '  <tr>';
        if (day == i)
            html += '<td class="today">' + i + '</td>';
        else
            html += '<td>' + i + '</td>';
        week++;
        if (week == 7) {
            html += '</tr>\n';
            week=0;
        }
    }

    //next month
    for (let i=1; week!=0; i++) {
        html += '<td class="next-month">' + i + '</td>';
        week++;
        if (week == 7) {
            html += '</tr>\n';
            week = 0;
        }
    }

    html += '</table>';
    return html;
}
function calculateNextDay([year, month, day])  {
  let date = new Date(year, month-1, day);
  let oneDay = 24 * 60 * 60 * 1000;
  let nextDate = new Date(date.getTime() + oneDay);
  return nextDate.getFullYear() + "-" + (nextDate.getMonth() + 1) + '-' + nextDate.getDate();
}
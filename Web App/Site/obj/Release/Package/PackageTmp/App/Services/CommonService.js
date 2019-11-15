MainApp.service('CommonService', function () {
    this.TryGetDateFromValue = function (val, yearPos, monthPos, dayPos, separator) {
        if (!angular.isDate(val)) {
            if (val.indexOf(' ') > -1) {
                var data = val.split(' ')[0];
                var time = val.split(' ')[1];
                val = data.split(separator)[yearPos].toString() + '-' + data.split(separator)[monthPos].toString() + '-' + data.split(separator)[dayPos].toString() + ' ' + time;
            }
            else {
                val = data.split(separator)[yearPos].toString() + '-' + data.split(separator)[monthPos].toString() + '-' + data.split(separator)[dayPos].toString();
            }
        }
        return val;
    }
});
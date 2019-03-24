function GetDateFormat(value) {
    //return new Date(parseFloat(str.substr(6, 13))).toLocaleDateString();
    return new Date(parseInt(value.replace("/Date(", "").replace(")/", ""), 10)).toLocaleString()
}
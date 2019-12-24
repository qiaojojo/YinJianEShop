function setSize() {
    $('#theFrame').css("width", $(window).width());
}

//页面加载时设框架款宽度
$(document).ready(function () {
    setSize();
});

//人工拖扯窗口大小时，重设框架款宽度
$(window).resize(function () {
    setSize();
});
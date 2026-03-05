//Colors 

var chartGreen = 'rgba(140, 193, 82,1)'
var chartRed = 'rgba(218, 68, 83,1)'
var chartBlue = 'rgba(74, 137, 220,1)'
var chartMagenta = 'rgba(150, 122, 220,1)'
var chartBrown = 'rgba(170, 142, 105,1)'
var chartOrange = 'rgba(233, 87, 63,1)'
var chartMint = 'rgba(55, 188, 155,1)'

var PersonaltypeValue = document.getElementById("hddSummaryPersonalType").value.split(',').map(str => Number(str));
var RegistertypeValue = document.getElementById("hddSummaryRegisterType").value.split(',').map(str => Number(str));

var UIDMonthly = document.getElementById("hddUIDMonthly").value.split(',').map(str => Number(str));
var UIDLabel = document.getElementById("hddUIDLabel").value.split(',').map(str => Number(str));

var MonthlyHCRegisterCount = document.getElementById("hddMonthlyHCRegisterCount").value.split(',').map(str => Number(str));
var MonthlyHCRegisterLabel = document.getElementById("hddMonthlyHCRegisterLabel").value.split(',').map(str => Number(str));

var MonthlyFARegisterCount = document.getElementById("hddMonthlyFARegisterCount").value.split(',').map(str => Number(str));
var MonthlyFARegisterLabel = document.getElementById("hddMonthlyFARegisterLabel").value.split(',').map(str => Number(str));

var hddEventCount = document.getElementById("hddEventCount").value.split(',').map(str => Number(str));
var hddEventLabel = document.getElementById("hddEventLabel").value.split(',').map(str => Number(str));

var hddRegisterPGS10Count = document.getElementById("hddRegisterPGS10Count").value.split(',').map(str => Number(str));
var hddRegisterPGS10Label = document.getElementById("hddRegisterPGS10Label").value.split(',').map(str => Number(str));

//Exchange Page Chart
//BTC Chart




//Main Chart
var chartActivityOptions = {
    //series: [14, 73],
    //colors:[chartRed, chartGreen],
    series: PersonaltypeValue,
    colors: [chartRed, chartGreen, chartBlue],
    chart: {
        width: '320px',
        animations: { enabled: false },
        toolbar: { show: false },
        type: 'donut'
    },
    legend: {
        show: false,
        position: 'bottom'
    },
    grid: { show: false },
    xaxis: {
        labels: { show: false, },
        axisBorder: { show: false },
        axisTicks: { show: false, }
    },
    yaxis: { labels: { show: false } },
    dataLabels: { enabled: false },
    stroke: { width: 0 },
    tooltip: { enabled: false },
};

var chart = new ApexCharts(document.querySelector("#chart-activity"), chartActivityOptions);
chart.render();

var chartRegisterOptions = {
    //series: [14, 73],
    //colors:[chartRed, chartGreen],
    series: RegistertypeValue,
    colors: [chartRed, chartGreen, chartBlue],
    chart: {
        width: '320px',
        animations: { enabled: false },
        toolbar: { show: false },
        type: 'donut'
    },
    legend: {
        show: false,
        position: 'bottom'
    },
    grid: { show: false },
    xaxis: {
        labels: { show: false, },
        axisBorder: { show: false },
        axisTicks: { show: false, }
    },
    yaxis: { labels: { show: false } },
    dataLabels: { enabled: false },
    stroke: { width: 0 },
    tooltip: { enabled: false },
};

var chart1 = new ApexCharts(document.querySelector("#chart-register"), chartRegisterOptions);
chart1.render();


//Component Demo Charts
//Chart 1
var optionsChart1 = {
    chart: {
        type: 'area',
        toolbar: {
            show: false
        },
        animations: {
            enabled: false,
        }
    },
    series: [{
        name: 'Month',
        data: MonthlyHCRegisterCount,
    }],
    fill: {
        type: "gradient",
        gradient: {
            shadeIntensity: 1,
            opacityFrom: 0.7,
            opacityTo: 0.9,
            stops: [0, 90, 100]
        }
    },
    xaxis: {
        categories: MonthlyHCRegisterLabel
    }
}

var chartDemo1 = new ApexCharts(document.querySelectorAll("#charts-demo-1")[0], optionsChart1);
chartDemo1.render();

// FA Register chart
var optionsChart2 = {
    chart: {
        type: 'area',
        toolbar: {
            show: false
        },
        animations: {
            enabled: false,
        }
    },
    series: [{
        name: 'Month',
        data: MonthlyFARegisterCount,
    }
        //,{
        //name: 'PWA',
        //data: [40, 50, 65, 70, 89, 90, 95],
        //}
    ],
    fill: {
        type: "gradient",
        gradient: {
            shadeIntensity: 1,
            opacityFrom: 0.7,
            opacityTo: 0.9,
            stops: [0, 90, 100]
        }
    },
    xaxis: {
        categories: MonthlyFARegisterLabel
    }
}

var chartDemo2 = new ApexCharts(document.querySelectorAll("#charts-demo-2")[0], optionsChart2);
chartDemo2.render();


// FA Register chart
var optionsChart3 = {
    chart: {
        type: 'area',
        toolbar: {
            show: false
        },
        animations: {
            enabled: false,
        }
    },
    series: [{
        name: 'Month',
        data: UIDMonthly,
    }
        //,{
        //name: 'PWA',
        //data: [40, 50, 65, 70, 89, 90, 95],
        //}
    ],
    fill: {
        type: "gradient",
        gradient: {
            shadeIntensity: 1,
            opacityFrom: 0.7,
            opacityTo: 0.9,
            stops: [0, 90, 100]
        }
    },
    xaxis: {
        categories: UIDLabel
    }
}

var chartDemo3 = new ApexCharts(document.querySelectorAll("#charts-demo-UID")[0], optionsChart3);
chartDemo3.render();


// FA Register chart
var optionsChart4 = {
    chart: {
        type: 'area',
        toolbar: {
            show: false
        },
        animations: {
            enabled: false,
        }
    },
    series: [{
        name: 'Month',
        data: hddEventCount,
    }
        //,{
        //name: 'PWA',
        //data: [40, 50, 65, 70, 89, 90, 95],
        //}
    ],
    fill: {
        type: "gradient",
        gradient: {
            shadeIntensity: 1,
            opacityFrom: 0.7,
            opacityTo: 0.9,
            stops: [0, 90, 100]
        }
    },
    xaxis: {
        categories: hddEventLabel
    }
}

var chartDemo4 = new ApexCharts(document.querySelectorAll("#charts-demo-3")[0], optionsChart4);
chartDemo4.render();


// FA Register chart
var optionsChart5 = {
    chart: {
        type: 'area',
        toolbar: {
            show: false
        },
        animations: {
            enabled: false,
        }
    },
    series: [{
        name: 'Month',
        data: hddRegisterPGS10Count,
    }
        //,{
        //name: 'PWA',
        //data: [40, 50, 65, 70, 89, 90, 95],
        //}
    ],
    fill: {
        type: "gradient",
        gradient: {
            shadeIntensity: 1,
            opacityFrom: 0.7,
            opacityTo: 0.9,
            stops: [0, 90, 100]
        }
    },
    xaxis: {
        categories: hddRegisterPGS10Label
    }
}

var chartDemo5 = new ApexCharts(document.querySelectorAll("#charts-demo-5")[0], optionsChart5);
chartDemo5.render();
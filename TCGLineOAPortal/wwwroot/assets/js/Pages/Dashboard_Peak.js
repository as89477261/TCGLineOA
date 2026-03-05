'use strict'
$(window).on('load', function () {

    window.randomScalingFactor = function () {
        return Math.round(Math.random() * 20);
    }

    window.randomScalingFactor2 = function () {
        return Math.round(Math.random() * 10);
    }
    /* bar chart */
    var areachart = document.getElementById('areachart1').getContext('2d');
    var areachart1 = areachart.createLinearGradient(0, 0, 0, 195);
    areachart1.addColorStop(0, 'rgba(1, 94, 194, 0.4)');
    areachart1.addColorStop(1, 'rgba(0, 197, 221, 0)');
    var areachart2 = areachart.createLinearGradient(0, 0, 0, 190);
    areachart2.addColorStop(0, 'rgba(240, 61, 79, 0.4)');
    areachart2.addColorStop(1, 'rgba(255, 223, 220, 0)');
    var areachart3 = areachart.createLinearGradient(0, 0, 0, 195);
    areachart3.addColorStop(0, 'rgba(145, 195, 0, 0.85)');
    areachart3.addColorStop(1, 'rgba(176, 197, 0, 0)');
    var myareachart = {
        type: 'line',
        data: {
            labels: ['Jan-15', 'Jan-30', 'Feb-15', 'Feb-30', 'Mar-15', 'Mar-30', 'Apr-15', 'Apr-30', 'May-15', 'May-30', 'Jun-15', 'Jun-30', 'Jul-15', 'Jul-30', 'Aug-15', 'Aug-30'],
            datasets: [{
                label: '# income',
                data: [
                    randomScalingFactor(),
                    randomScalingFactor(),
                    randomScalingFactor(),
                    randomScalingFactor(),
                    randomScalingFactor(),
                    randomScalingFactor(),
                    randomScalingFactor(),
                    randomScalingFactor(),
                    randomScalingFactor(),
                    randomScalingFactor(),
                    randomScalingFactor(),
                    randomScalingFactor(),
                    randomScalingFactor(),
                    randomScalingFactor(),
                    randomScalingFactor(),
                    randomScalingFactor(),
                    randomScalingFactor(),
                    randomScalingFactor(),
                ],
                radius: 2,
                pointBackgroundColor: '#ffffff',
                backgroundColor: areachart3,
                borderColor: '#91C300',
                borderWidth: 1,
                fill: true,
                tension: 0.3,
            }, {
                label: '# of Expense',
                data: [
                    randomScalingFactor2(),
                    randomScalingFactor2(),
                    randomScalingFactor2(),
                    randomScalingFactor2(),
                    randomScalingFactor2(),
                    randomScalingFactor2(),
                    randomScalingFactor2(),
                    randomScalingFactor2(),
                    randomScalingFactor2(),
                    randomScalingFactor2(),
                    randomScalingFactor2(),
                    randomScalingFactor2(),
                    randomScalingFactor2(),
                    randomScalingFactor2(),
                    randomScalingFactor2(),
                    randomScalingFactor2(),
                    randomScalingFactor2(),
                    randomScalingFactor2(),
                ],
                radius: 2,
                pointBackgroundColor: '#ffffff',
                backgroundColor: areachart2,
                borderColor: 'rgba(240, 61, 79, 0.65)',
                borderWidth: 1,
                fill: true,
                tension: 0.3,
            }, {
                label: '# of Investments',
                data: [
                    randomScalingFactor2(),
                    randomScalingFactor2(),
                    randomScalingFactor2(),
                    randomScalingFactor2(),
                    randomScalingFactor2(),
                    randomScalingFactor2(),
                    randomScalingFactor2(),
                    randomScalingFactor2(),
                    randomScalingFactor2(),
                    randomScalingFactor2(),
                    randomScalingFactor2(),
                    randomScalingFactor2(),
                    randomScalingFactor2(),
                    randomScalingFactor2(),
                    randomScalingFactor2(),
                    randomScalingFactor2(),
                    randomScalingFactor2(),
                    randomScalingFactor2(),
                ],
                radius: 2,
                pointBackgroundColor: '#ffffff',
                backgroundColor: areachart1,
                borderColor: 'rgba(1, 94, 194, 0.4)',
                borderWidth: 1,
                fill: true,
                tension: 0.3,
            }]
        },
        options: {
            layout: {
                padding: 0,
            },
            maintainAspectRatio: true,
            plugins: {
                legend: {
                    display: true,
                },
            },
            scales: {
                y: {
                    display: true,
                    beginAtZero: true,
                },
                x: {
                    grid: {
                        display: true
                    },
                    display: true,
                    beginAtZero: false,
                }
            }
        }
    }
    var myareachartexecu = new Chart(areachart, myareachart);
    /* my area chart randomize */
    setInterval(function () {
        myareachart.data.datasets.forEach(function (dataset) {
            dataset.data = dataset.data.map(function () {
                return randomScalingFactor();
            });
        });
        myareachartexecu.update();
    }, 1500);




});

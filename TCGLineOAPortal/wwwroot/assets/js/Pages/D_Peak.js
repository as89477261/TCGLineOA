'use strict'
$(window).on('load', function () {
    var hddPeakChartValue = document.getElementById('hddPeakValue').value.split(',');
    var hddPeakChartLabel = document.getElementById('hddPeakLabel').value.split(',')

    $('.datepickerInsert').datepicker({ language: 'th-th', format: 'dd/mm/yyyy' })
    $('.datepickerInsert').datepicker('update', new Date());
    $('.datepicker').datepicker({ language: 'th-th', format: 'dd/mm/yyyy' })

    /* Swiper slider */
    var swiper = new Swiper(".categorychartswiper", {
        slidesPerView: 1,
        spaceBetween: 20,
        loop: true,
        autoplay: {
            delay: 3000,
            disableOnInteraction: false,
        },
        navigation: {
            nextEl: ".swiper-button-next",
            prevEl: ".swiper-button-prev",
        },
        breakpoints: {
            640: {
                slidesPerView: 1,
            },
            768: {
                slidesPerView: 2,
            },
            992: {
                slidesPerView: 3,
            },
            1024: {
                slidesPerView: 3,
            },
            1200: {
                slidesPerView: 1,
            },
            1600: {
                slidesPerView: 2,
            },
        }
    });

    /* chart js areachart */
    window.randomScalingFactor = function () {
        return Math.round(Math.random() * 20);
    }  

    /* my area chart randomize */

    /* area chart yelow large size */
    var areachartsocialtraffic = document.getElementById('socialtraffic').getContext('2d');
    var gradientsocialtrafficblue = areachartsocialtraffic.createLinearGradient(0, 0, 0, 235);
    gradientsocialtrafficblue.addColorStop(0, 'rgba(1, 94, 194, 0.85)');
    gradientsocialtrafficblue.addColorStop(1, 'rgba(0, 197, 221, 0)');

    var gradientsocialtrafficred1 = areachartsocialtraffic.createLinearGradient(0, 0, 0, 220);
    gradientsocialtrafficred1.addColorStop(0, 'rgba(240, 61, 79, 0.85)');
    gradientsocialtrafficred1.addColorStop(1, 'rgba(255, 223, 220, 0)');
    var myareachartsocialtrafficConfig = {
        type: 'line',
        data: {
            labels: hddPeakChartLabel,
            datasets: [{
                label: '# of Votes',
                data: hddPeakChartValue,
                radius: 0,
                backgroundColor: gradientsocialtrafficblue,
                borderColor: '#015EC2',
                borderWidth: 1,
                fill: true,
                tension: 0.35,
            },
            //{
            //    label: '# of Votes',
            //    data: [
            //        randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor(),
            //        randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor()
            //    ],
            //    radius: 0,
            //    backgroundColor: gradientsocialtrafficred1,
            //    borderColor: '#f03d4f',
            //    borderWidth: 1,
            //    fill: true,
            //    tension: 0.35,
            //    }

            ]
        },
        options: {
            maintainAspectRatio: false,
            plugins: {
                legend: {
                    display: false,
                },
            },
            scales: {
                y: {
                    ticks: {
                        color: '#999999'
                    },
                    display: true,
                    beginAtZero: true,
                    grid: {
                        display: true,
                        color: 'rgba(0,0,0,0.04)',
                        drawBorder: true,
                        lineWidth: 1,
                        zeroLineWidth: 1
                    }
                },
                x: {
                    ticks: {
                        color: '#999999',
                    },
                    display: true,
                    grid: {
                        display: true,
                        color: 'rgba(0,0,0,0.04)',
                        drawBorder: true,
                        lineWidth: 1,
                        zeroLineWidth: 1
                    }
                }
            }
        }
    }
    var myAreaChartsocialtraffic = new Chart(areachartsocialtraffic, myareachartsocialtrafficConfig);
    /* my area chart randomize */
    myAreaChartsocialtraffic.update();

});

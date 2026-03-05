'use strict'
$(window).on('load', function () {
    
    /* swiper js */
    var swiper2 = new Swiper(".swiperauto", {
        slidesPerView: "auto",
        spaceBetween: 30,
        centeredSlides: false,
        autoplay: true,
    });


    /* circular progress */
    var progressCircles1 = new ProgressBar.Circle(circleprogressblue, {
        color: '#015EC2',
        // This has to be the same size as the maximum width to
        // prevent clipping
        strokeWidth: 10,
        trailWidth: 10,
        easing: 'easeInOut',
        trailColor: 'rgba(66, 157, 255, 0.15)',
        duration: 1400,
        text: {
            autoStyleContainer: false
        },
        from: { color: '#015EC2', width: 10 },
        to: { color: '#015EC2', width: 10 },
        // Set default step function for all animate calls
        step: function (state, circle) {
            circle.path.setAttribute('stroke', state.color);
            circle.path.setAttribute('stroke-width', state.width);

            var value = Math.round(circle.value() * 100);
            if (value === 0) {
                //  circle.setText('');
            } else {
                // circle.setText(value + "<small>%<small>");
            }

        }
    });
    // progressCircles2.text.style.fontSize = '20px';
    progressCircles1.animate(1.0);  // Number from 0.0 to 1.0

    /* circular progress */
    var progressCircles2 = new ProgressBar.Circle(circleprogressyellow, {
        color: '#ffc107',
        // This has to be the same size as the maximum width to
        // prevent clipping
        strokeWidth: 10,
        trailWidth: 10,
        easing: 'easeInOut',
        trailColor: 'rgba(255, 200, 0, 0.3)',
        duration: 1400,
        text: {
            autoStyleContainer: false
        },
        from: { color: '#ffc107', width: 10 },
        to: { color: '#ffc107', width: 10 },
        // Set default step function for all animate calls
        step: function (state, circle) {
            circle.path.setAttribute('stroke', state.color);
            circle.path.setAttribute('stroke-width', state.width);

            var value = Math.round(circle.value() * 100);
            if (value === 0) {
                //  circle.setText('');
            } else {
                // circle.setText(value + "<small>%<small>");
            }

        }
    });
    // progressCircles2.text.style.fontSize = '20px';
    progressCircles2.animate(0.85);  // Number from 0.0 to 1.0

    /* circular progress */
    var progressCirclesgreen = new ProgressBar.Circle(circleprogressgreen, {
        color: '#91C300',
        // This has to be the same size as the maximum width to
        // prevent clipping
        strokeWidth: 10,
        trailWidth: 10,
        easing: 'easeInOut',
        trailColor: 'rgba(120, 195, 0, 0.15)',
        duration: 1400,
        text: {
            autoStyleContainer: false
        },
        from: { color: '#91C300', width: 10 },
        to: { color: '#91C300', width: 10 },
        // Set default step function for all animate calls
        step: function (state, circle) {
            circle.path.setAttribute('stroke', state.color);
            circle.path.setAttribute('stroke-width', state.width);

            var value = Math.round(circle.value() * 100);
            if (value === 0) {
                //  circle.setText('');
            } else {
                // circle.setText(value + "<small>%<small>");
            }

        }
    });
    // progressCirclesred.text.style.fontSize = '20px';
    progressCirclesgreen.animate(0.45);  // Number from 0.0 to 1.0

    /* circular progress */
    var progressCircleredbug = new ProgressBar.Circle(circleprogressredbug, {
        color: '#dd2739',
        // This has to be the same size as the maximum width to
        // prevent clipping
        strokeWidth: 10,
        trailWidth: 10,
        easing: 'easeInOut',
        trailColor: 'rgba(240, 61, 79, 0.15)',
        duration: 1400,
        text: {
            autoStyleContainer: false
        },
        from: { color: '#dd2739', width: 10 },
        to: { color: '#dd2739', width: 10 },
        // Set default step function for all animate calls
        step: function (state, circle) {
            circle.path.setAttribute('stroke', state.color);
            circle.path.setAttribute('stroke-width', state.width);

            var value = Math.round(circle.value() * 100);
            if (value === 0) {
                //  circle.setText('');
            } else {
                // circle.setText(value + "<small>%<small>");
            }

        }
    });
    // progressCirclesred.text.style.fontSize = '20px';
    progressCircleredbug.animate(0.68);  // Number from 0.0 to 1.0

    /* circular progress */
    var progressCirclesblue2 = new ProgressBar.Circle(circleprogressblue2, {
        color: '#015EC2',
        // This has to be the same size as the maximum width to
        // prevent clipping
        strokeWidth: 10,
        trailWidth: 10,
        easing: 'easeInOut',
        trailColor: 'rgba(66, 157, 255, 0.15)',
        duration: 1400,
        text: {
            autoStyleContainer: false
        },
        from: { color: '#015EC2', width: 10 },
        to: { color: '#015EC2', width: 10 },
        // Set default step function for all animate calls
        step: function (state, circle) {
            circle.path.setAttribute('stroke', state.color);
            circle.path.setAttribute('stroke-width', state.width);

            var value = Math.round(circle.value() * 100);
            if (value === 0) {
                // circle.setText('');
            } else {
                // circle.setText(value + "<small>%<small>");
            }

        }
    });
    // progressCirclesred1.text.style.fontSize = '20px';
    progressCirclesblue2.animate(0.75);  // Number from 0.0 to 1.0


    /* chart js */
    window.randomScalingFactor = function () {
        return Math.round(Math.random() * 20);
    }

   


});

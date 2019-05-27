gulp = require('gulp'),
sass = require("gulp-sass"),
uglify = require("gulp-uglify"),
concat = require('gulp-concat'),
newer = require('gulp-newer'),
clean = require('gulp-clean'),
sourcemaps = require('gulp-sourcemaps');

const { parallel, series } = require('gulp');

// task
gulp.task('clean', function() {
    return gulp.src('dist/development', {read: false, allowEmpty: true})
    .pipe(clean());
});

gulp.task('copy-vendor', function() {

    var files = [
        {
            "source": "node_modules/requirejs/require.js",
            "dest": "js/vendor/require.js"
        },
        {
            "source": "node_modules/jquery/dist/jquery.js",
            "dest": "js/vendor/jquery.js"
        }        
    ];

    for (var t=0; t<files.length; t++) {
        var file = files[t];

        gulp.src(file["source"])
        .pipe(newer(file["dest"]))
          .pipe(gulp.dest('js/vendor'));        
    }

    return Promise.resolve('Done');
  });


gulp.task('gulp-sass', function () {
    return gulp.src('sass/styles.scss') // path to your file
    .pipe(sourcemaps.init())
    .pipe(sass({
        outputFile: 'expanded'
    }))
    .pipe(sourcemaps.write())
    .pipe(gulp.dest('dist/development/css'));
});

gulp.task('gulp-js', function () {
    return gulp.src(['js/**/*.js'])
    .pipe(gulp.dest('dist/development/js'));
});

gulp.task('gulp-template', function () {
    return gulp.src(['template/**/*.html'])
    .pipe(gulp.dest('dist/development/template'));
});


gulp.task('default', series('clean', 'copy-vendor', parallel('gulp-sass', 'gulp-js', 'gulp-template')));
gulp = require('gulp'),
sass = require("gulp-sass"),
uglify = require("gulp-uglify"),
concat = require('gulp-concat'),
newer = require('gulp-newer'),
clean = require('gulp-clean');

const { parallel, series } = require('gulp');

// task
gulp.task('clean', function() {
    return gulp.src('dist/development', {read: false})
    .pipe(clean());
});

gulp.task('copy-require', function() {
    return gulp.src('node_modules/requirejs/require.js')
    .pipe(newer('js/vendor/require.js'))
      .pipe(gulp.dest('js/vendor'));
  });


gulp.task('gulp-sass', function () {
    return gulp.src('sass/styles.scss') // path to your file
    .pipe(sass())
    .pipe(gulp.dest('dist/development/css'));
});

gulp.task('gulp-js', function () {
    return gulp.src(['js/**/*.js'])
    .pipe(gulp.dest('dist/development/js'));
});


gulp.task('default', series('clean', 'copy-require', parallel('gulp-sass', 'gulp-js')));
gulp = require('gulp'),
sass = require("gulp-sass"),
uglify = require("gulp-uglify"),
concat = require('gulp-concat'),
newer = require('gulp-newer')

const { parallel, series } = require('gulp');

// task
gulp.task('gulp-sass', function () {
    return gulp.src('sass/styles.scss') // path to your file
    .pipe(sass())
    .pipe(gulp.dest('dist/development/css'));
});

gulp.task('copy-require', function() {
    return gulp.src('node_modules/requirejs/require.js')
    .pipe(newer('react/vendor/require.js'))
      .pipe(gulp.dest('react/vendor'));
  });

gulp.task('gulp-js-vendor', function () {
    return gulp.src(['react/vendor/*.js'])
    .pipe(gulp.dest('dist/development/js/vendor'));
});

gulp.task('gulp-js', function () {
    return gulp.src(['react/*.js'])
    .pipe(uglify())
    .pipe(gulp.dest('dist/development/js'));
});


gulp.task('default', parallel('gulp-sass', series('copy-require','gulp-js-vendor')));
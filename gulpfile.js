const gulp        = require('gulp');
const browserSync = require('browser-sync');
const sass        = require('gulp-sass')(require('sass'));
const cleanCSS = require('gulp-clean-css');
const autoprefixer = require('gulp-autoprefixer');
const rename = require("gulp-rename");

gulp.task('server', function() {

    browserSync({
        server: {
            baseDir: "SafeCity/SafeCity.Client/wwwroot"
        }
    });

    gulp.watch("SafeCity/SafeCity.Client/wwwroot/*.html").on('change', browserSync.reload);
});

gulp.task('styles', function() {
    return gulp.src("SafeCity/SafeCity.Client/wwwroot/sass/**/*.+(scss|sass)")
        .pipe(sass({outputStyle: 'compressed'}).on('error', sass.logError))
        .pipe(sass.sync())
        .pipe(rename({suffix: '.min', prefix: ''}))
        .pipe(autoprefixer())
        .pipe(cleanCSS({compatibility: 'ie8'}))
        .pipe(gulp.dest("SafeCity/SafeCity.Client/wwwroot/css"))
        .pipe(browserSync.stream());
});

gulp.task('watch', function() {
    gulp.watch("SafeCity/SafeCity.Client/wwwroot/sass/**/*.+(scss|sass)", gulp.parallel('styles'));
});

gulp.task('default', gulp.parallel('watch', 'server', 'styles'));
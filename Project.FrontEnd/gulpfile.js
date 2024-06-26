/// <binding AfterBuild='min:html, min:css, gzip, watch' />
"use strict";

var gulp = require("gulp"),
    concat = require("gulp-concat"),
    cssmin = require("gulp-cssmin"),
    htmlmin = require("gulp-htmlmin"),
    uglify = require("gulp-uglify"),
    merge = require("merge-stream"),
    bundleconfig = require("./bundleconfig.json");
var gzip = require('gulp-gzip');
var regex = {
    css: /\.css$/,
    html: /\.(html|htm)$/,
    js: /\.js$/
};

gulp.task("min:js", function () {
    var tasks = getBundles(regex.js).map(function (bundle) {
        return gulp.src(bundle.inputFiles, { base: "." })
            .pipe(concat(bundle.outputFileName))
            .pipe(uglify())
            .pipe(gulp.dest("."));
    });
    return merge(tasks);
});

gulp.task("min:css", function () {
    var tasks = getBundles(regex.css).map(function (bundle) {
        return gulp.src(bundle.inputFiles, { base: "." })
            .pipe(concat(bundle.outputFileName))
            .pipe(cssmin())
            .pipe(gulp.dest("."));
    });
    return merge(tasks);
});

gulp.task("min:html", function () {
    var tasks = getBundles(regex.html).map(function (bundle) {
        return gulp.src(bundle.inputFiles, { base: "." })
            .pipe(concat(bundle.outputFileName))
            .pipe(htmlmin({ collapseWhitespace: true, minifyCSS: true, minifyJS: true }))
            .pipe(gulp.dest("."));
    });
    return merge(tasks);
});

gulp.task("clean", function () {
    var files = bundleconfig.map(function (bundle) {
        return bundle.outputFileName;
    });

    return del(files);
});

gulp.task('gzip', function () {
    return gulp.src('wwwroot/srcjs/*')
        .pipe(gzip())
        .pipe(gulp.dest('wwwroot/jszip/'));
});

//gulp.task("watch", function () {
//    getBundles(regex.js).forEach(function (bundle) {
//        gulp.watch(bundle.inputFiles, ["min:js"]);
//    });

//    getBundles(regex.css).forEach(function (bundle) {
//        gulp.watch(bundle.inputFiles, ["min:css"]);
//    });

//    getBundles(regex.html).forEach(function (bundle) {
//        gulp.watch(bundle.inputFiles, ["min:html"]);
//    });
//});

function getBundles(regexPattern) {
    return bundleconfig.filter(function (bundle) {
        return regexPattern.test(bundle.outputFileName);
    });
}
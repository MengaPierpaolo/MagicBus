"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = require('@angular/core');
var experience_list_1 = require('../component/experience-list');
var data_service_1 = require('../service/data.service');
var AppComponent = (function () {
    function AppComponent(dataService) {
        this.dataService = dataService;
        this.pageDetails = {
            Title: "Magic Bus",
            SubTitle: "Your groovy new travel diary - In Angular 2!"
        };
    }
    AppComponent.prototype.getApplicationData = function () {
        return this.dataService.getRecentExperiences();
    };
    AppComponent = __decorate([
        core_1.Component({
            selector: 'tdiary-app',
            template: "\n    <div class=\"jumbotron\">\n      <h1>{{pageDetails.Title}}</h1>\n      <h2>{{pageDetails.SubTitle}}</h2>\n    </div>\n    <div class=\"content row\">\n      <div class=\"col-sm-6\">\n          <label>Wotcha been up to?</label><br>\n          <button class=\"btn btn-primary\">Been on a trip</button>\n          <button class=\"btn btn-primary\">Had some chow</button>\n          <button class=\"btn btn-primary\">Seen something funky</button>\n      </div>\n      <div class=\"col-sm-6\">\n        <experience-list [activityData]=\"getApplicationData()\"></experience-list>\n      </div>\n    </div>\n    ",
            directives: [experience_list_1.ExperienceListComponent],
            providers: [data_service_1.DataService]
        }), 
        __metadata('design:paramtypes', [data_service_1.DataService])
    ], AppComponent);
    return AppComponent;
}());
exports.AppComponent = AppComponent;
//# sourceMappingURL=app.js.map
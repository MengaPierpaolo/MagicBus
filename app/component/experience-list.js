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
var ExperienceListComponent = (function () {
    function ExperienceListComponent() {
    }
    ExperienceListComponent.prototype.clickMe = function (clickedThing) {
        this.selectedActivity = clickedThing;
    };
    __decorate([
        core_1.Input(), 
        __metadata('design:type', Array)
    ], ExperienceListComponent.prototype, "activityData", void 0);
    ExperienceListComponent = __decorate([
        core_1.Component({
            selector: 'experience-list',
            template: "\n    <form class=\"form-inline\">\n    <label>Recent experiences:</label>\n      <div *ngFor=\"let activity of activityData\">\n          <a href=\"#\" (click)=\"clickMe(activity)\" class=\"delete-cross\">X</a>\n          <a href=\"#\" (click)=\"clickMe(activity)\">{{activity.Experience}}</a>\n      </div>\n    <label *ngIf=\"selectedActivity\">{{selectedActivity.Experience}}</label>\n    </form>\n    ",
        }), 
        __metadata('design:paramtypes', [])
    ], ExperienceListComponent);
    return ExperienceListComponent;
}());
exports.ExperienceListComponent = ExperienceListComponent;
//# sourceMappingURL=experience-list.js.map
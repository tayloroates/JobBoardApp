namespace JobBoardApp.Services {
    export class JobService {
        public jobResource;

        public getJobs() {
            return this.jobResource.query();
        }
        public addUser(jobId, user) {
            return this.jobResource.save({ id: jobId }, user);
        }
        public save(job) {
            return this.jobResource.save(job).$promise;
        }
        public deleteJob(id: number) {
            return this.jobResource.delete({ id: id }).$promise;
        }
        public addJob(id: number) {
            return this.jobResource.save({id: id }).$promise
        }
        public getJob(id) {
            return this.jobResource.get({ id: id });
        }
        constructor($resource: ng.resource.IResourceService) {
            this.jobResource = $resource('/api/jobs/:id');
        }

    }
    angular.module('JobBoardApp').service('JobService', JobService);

}


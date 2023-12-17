class LectureLab {
  lectureLabId: number;
  type: string;
  code: string;
  startDate: Date;
  endDate: Date;
  teacher: string;
  location: string;
  description: string;
}

export class Course {
  courseId: number;
  name: string;
  code: string;
  category: string;
  credit: number;
  description: string;
  instanceDescription: string;
  startDate: Date;
  endDate: Date;
  lectures: LectureLab[];
  labs: LectureLab[];
}

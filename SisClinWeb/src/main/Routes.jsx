import React from 'react'
import { Switch, Route, Redirect } from 'react-router'

import Home from '../components/home/Home'
import EmployeeCrud from '../components/employee/EmployeeCrud'
import PersonCrud from '../components/person/PersonCrud'
import DepartmentCrud from '../components/department/DepartmentCrud'
import ProceedingCrud from '../components/proceeding/ProceedingCrud'
import AttendanceCrud from '../components/attendance/AttendanceCrud'

export default props =>
    <Switch>
        <Route exact path='/' component={Home} />
        <Route exact path='/employee' component={EmployeeCrud} />
        <Route exact path='/person' component={PersonCrud} />
        <Route exact path='/department' component={DepartmentCrud} />
        <Route exact path='/proceeding' component={ProceedingCrud} />
        <Route exact path='/attendance' component={AttendanceCrud} />
        <Redirect from='*' to='/' />
    </Switch>
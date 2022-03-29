import React, { Component } from 'react'
import axios from 'axios'
import Main from '../template/Main'

const headerProps = {
    icon: 'users',
    title: 'Funcionário',
    subtitle: 'Cadastro de Funcionário'
}

const baseUrl = 'http://localhost:52727/api/Employee'
const initialState = {
    Employee: { EmployeeName: '', Department: '', EmployeeRg: '', EmployeeCpf: '', EmployeeStatus: '' },
    list: []
}

export default class EmployeeCrud extends Component {
    state = { ...initialState }

    componentWillMount() {
        axios(baseUrl).then(resp => {
            this.setState({ list: resp.data })
        })
    }

    clear() {
        this.setState({ Employee: initialState.Employee })
    }

    save() {
        const Employee = this.state.Employee;
        Employee.EmployeeRg = parseInt(Employee.EmployeeRg);
        Employee.EmployeeCpf = parseInt(Employee.EmployeeCpf);
        Employee.EmployeeStatus = parseInt(Employee.EmployeeStatus);
        const method = Employee.id ? 'put' : 'post'
        const url = Employee.id ? `${baseUrl}/${Employee.id}` : baseUrl
        axios[method](url, Employee)
            .then(resp => {
                const list = this.getUpdatedList(resp.data)
                this.setState({ Employee: initialState.Employee, list })
            })
    }

    getUpdatedList(Employee, add = true) {
        const list = this.state.list.filter(e => e.id !== Employee.id)
        if (add) list.unshift(Employee)
        return list
    }

    updateField(event) {
        const Employee = { ...this.state.Employee }
        Employee[event.target.name] = event.target.value
        this.setState({ Employee })
    }

    renderForm() {
        return (
            <div className="form">
                <div className="row">
                    <div className="col-12 col-md-6">
                        <div className="form-group">
                            <label>Nome</label>
                            <input type="text" className="form-control"
                                name="EmployeeName"
                                value={this.state.Employee.EmployeeName}
                                onChange={e => this.updateField(e)}
                                placeholder="Digite o nome..." />
                        </div>
                    </div>
                    <div className="col-12 col-md-6">
                        <div className="form-group">
                            <label>Departamento</label>
                            <input type="text" className="form-control"
                                name="Departamento"
                                value={this.state.Employee.Departamento}
                                onChange={e => this.updateField(e)}
                                placeholder="Digite o Departamento..." />
                        </div>
                    </div>
                    <div className="col-12 col-md-6">
                        <div className="form-group">
                            <label>RG</label>
                            <input type="text" className="form-control"
                                name="EmployeeRg"
                                value={this.state.Employee.EmployeeRG}
                                onChange={e => this.updateField(e)}
                                placeholder="Digite o RG..." />
                        </div>
                    </div>
                    <div className="col-12 col-md-6">
                        <div className="form-group">
                            <label>CPF</label>
                            <input type="text" className="form-control"
                                name="EmployeeCpf"
                                value={this.state.Employee.EmployeeCpf}
                                onChange={e => this.updateField(e)}
                                placeholder="Digite o CPF..." />
                        </div>
                    </div>
                    <div className="col-12 col-md-6">
                        <div className="form-group">
                            <label>Status</label>
                            <input type="text" className="form-control"
                                name="EmployeeStatus"
                                value={this.state.Employee.EmployeeStatus}
                                onChange={e => this.updateField(e)}
                                placeholder="Digite o Status..." />
                        </div>
                    </div>

                </div>
                <hr />
                <div className="row">
                    <div className="col-12 d-flex justify-content-end">
                        <button className="btn btn-primary" onClick={e => this.save(e)}>Salvar</button>
                        <button className="btn btn-secondary ml-2" onClick={e => this.clear(e)}>Cancelar</button>
                    </div>
                </div>
            </div>
        )
    }

    load(Employee) {
        this.setState({ Employee })
    }

    remove(Employee) {
        axios.delete(`${baseUrl}/${Employee.id}`).then(resp => {
            const list = this.getUpdatedList(Employee, false)
            this.setState({ list })
        })
    }

    renderTable() {
        return (
            <table className="table mt-4">
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Nome</th>
                        <th>Departamento</th>
                        <th>RG</th>
                        <th>CPF</th>
                        <th>Status</th>
                        <th>Ações</th>
                    </tr>
                </thead>
                <tbody>
                    {this.renderRows()}
                </tbody>
            </table>
        )
    }

    renderRows() {
        return this.state.list.map(Employee => {
            return (
                <tr key={Employee.id}>
                    <td>{Employee.EmployeeId}</td>
                    <td>{Employee.EmployeeName}</td>
                    <td>{Employee.Department}</td>
                    <td>{Employee.EmployeeRg}</td>
                    <td>{Employee.EmployeeCpf}</td>
                    <td>{Employee.EmployeeStatus}</td>
                    <td>
                        <button className="btn btn-warning" onClick={() => this.load(Employee)} >
                            <i className="fa fa-pencil"></i>
                        </button>
                        <button className="btn btn-danger ml-2" onClick={() => this.remove(Employee)} >
                            <i className="fa fa-trash"></i>
                        </button>
                    </td>
                </tr>
            )
        })
    }

    render() {
        return (
            <Main {...headerProps}>
                {this.renderForm()}
                {this.renderTable()}
            </Main>
        )
    }
}
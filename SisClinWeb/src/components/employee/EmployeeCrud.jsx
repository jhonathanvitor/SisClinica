import React, { Component } from 'react'
import axios from 'axios'
import Main from '../template/Main'

const headerProps = {
    icon: 'users',
    title: 'Funcionário',
    subtitle: 'Cadastro de Funcionário'
}

const baseUrl = 'http://localhost:5000/api/Employers'
const initialState = {
    Employer: { EmployerName: '', EmployerRg: '', EmployerCpf: '', Tipe: '' },
    list: []
}

export default class EmployerCrud extends Component {
    state = { ...initialState }

    componentWillMount() {
        axios(baseUrl).then(resp => {
            this.setState({ list: resp.data })
        })
    }

    clear() {
        this.setState({ Employer: initialState.Employer })
    }

    save() {
        const Employer = this.state.Employer;
        Employer.EmployerName = parseInt(Employer.EmployerName);
        Employer.EmployerRg = parseInt(Employer.EmployerRg);
        Employer.EmployerCpf = parseInt(Employer.EmployerCpf);
        Employer.Tipe = parseInt(Employer.Tipe);
        const method = Employer.id ? 'put' : 'post'
        const url = Employer.id ? `${baseUrl}/${Employer.id}` : baseUrl
        axios[method](url, Employer)
            .then(resp => {
                const list = this.getUpdatedList(resp.data)
                this.setState({ Employer: initialState.Employer, list })
            })
    }

    getUpdatedList(Employer, add = true) {
        const list = this.state.list.filter(e => e.id !== Employer.id)
        if (add) list.unshift(Employer)
        return list
    }

    updateField(event) {
        const Employer = { ...this.state.Employer }
        Employer[event.target.name] = event.target.value
        this.setState({ Employer })
    }

    renderForm() {
        return (
            <div className="form">
                <div className="row">
                    <div className="col-12 col-md-6">
                        <div className="form-group">
                            <label>Nome</label>
                            <input type="text" className="form-control"
                                name="EmployerName"
                                value={this.state.Employer.EmployerName}
                                onChange={e => this.updateField(e)}
                                placeholder="Digite o nome..." />
                        </div>
                    </div>
                    <div className="col-12 col-md-6">
                        <div className="form-group">
                            <label>RG</label>
                            <input type="text" className="form-control"
                                name="EmployerRg"
                                value={this.state.Employer.EmployerRG}
                                onChange={e => this.updateField(e)}
                                placeholder="Digite o RG..." />
                        </div>
                    </div>
                    <div className="col-12 col-md-6">
                        <div className="form-group">
                            <label>CPF</label>
                            <input type="text" className="form-control"
                                name="EmployerCpf"
                                value={this.state.Employer.EmployerCpf}
                                onChange={e => this.updateField(e)}
                                placeholder="Digite o CPF..." />
                        </div>
                    </div>
                    <div className="col-12 col-md-6">
                        <div className="form-group">
                            <label>Tipe</label>
                            <input type="text" className="form-control"
                                name="EmployerStatus"
                                value={this.state.Employer.Tipe}
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

    load(Employer) {
        this.setState({ Employer })
    }

    remove(Employer) {
        axios.delete(`${baseUrl}/${Employer.id}`).then(resp => {
            const list = this.getUpdatedList(Employer, false)
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
                        <th>RG</th>
                        <th>CPF</th>
                        <th>Tipo</th>
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
        return this.state.list.map(Employer => {
            return (
                <tr key={Employer.id}>
                    <td>{Employer.EmployerId}</td>
                    <td>{Employer.EmployerName}</td>
                    <td>{Employer.EmployerRg}</td>
                    <td>{Employer.EmployerCpf}</td>
                    <td>{Employer.Tipe}</td>
                    <td>
                        <button className="btn btn-warning" onClick={() => this.load(Employer)} >
                            <i className="fa fa-pencil"></i>
                        </button>
                        <button className="btn btn-danger ml-2" onClick={() => this.remove(Employer)} >
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
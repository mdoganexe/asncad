import { useState, useEffect } from 'react'
import { useQuery, useMutation } from '@tanstack/react-query'
import { companyInfoApi } from '../api/services'
import type { CompanyInfo, UpdateCompanyInfoRequest } from '../types'

const MAX_LEN = 255

export default function CompanyInfoPage() {
  const [form, setForm] = useState<UpdateCompanyInfoRequest>({})
  const [errors, setErrors] = useState<Record<string, string>>({})
  const [saved, setSaved] = useState(false)

  const { data, isLoading } = useQuery({ queryKey: ['companyInfo'], queryFn: companyInfoApi.get })

  useEffect(() => {
    if (data) {
      const { id, tenantId, ...rest } = data
      setForm(rest as UpdateCompanyInfoRequest)
    }
  }, [data])

  const mutation = useMutation({
    mutationFn: (d: UpdateCompanyInfoRequest) => companyInfoApi.update(d),
    onSuccess: () => { setSaved(true); setTimeout(() => setSaved(false), 3000) },
  })

  const set = (key: string, val: string) => {
    setForm(prev => ({ ...prev, [key]: val }))
    if (val.length > MAX_LEN) {
      setErrors(prev => ({ ...prev, [key]: `Maksimum ${MAX_LEN} karakter` }))
    } else {
      setErrors(prev => { const n = { ...prev }; delete n[key]; return n })
    }
  }

  const handleSave = () => {
    if (Object.keys(errors).length > 0) return
    mutation.mutate(form)
  }

  if (isLoading) return <p>Yükleniyor...</p>

  return (
    <div>
      <div className="flex-between" style={{ marginBottom: 24 }}>
        <h1>Firma Bilgileri</h1>
        <div className="flex">
          {saved && <span className="tag tag-success">✓ Kaydedildi</span>}
          <button className="btn-primary" onClick={handleSave} disabled={mutation.isPending || Object.keys(errors).length > 0}>
            {mutation.isPending ? 'Kaydediliyor...' : 'Kaydet'}
          </button>
        </div>
      </div>

      <Section title="Firma Bilgileri">
        <Field label="Firma Adı" field="ad" value={form.ad} error={errors.ad} onChange={set} />
        <Field label="Adres" field="adres" value={form.adres} error={errors.adres} onChange={set} />
        <Field label="Telefon" field="telefon" value={form.telefon} error={errors.telefon} onChange={set} />
        <Field label="Fax" field="fax" value={form.fax} error={errors.fax} onChange={set} />
        <Field label="E-posta" field="email" value={form.email} error={errors.email} onChange={set} />
        <Field label="Yetkili" field="yetkili" value={form.yetkili} error={errors.yetkili} onChange={set} />
        <Field label="Marka" field="marka" value={form.marka} error={errors.marka} onChange={set} />
        <Field label="Vergi Dairesi" field="vergiDairesi" value={form.vergiDairesi} error={errors.vergiDairesi} onChange={set} />
        <Field label="Vergi No" field="vergiNo" value={form.vergiNo} error={errors.vergiNo} onChange={set} />
      </Section>

      <Section title="Onaylı Kuruluş">
        <Field label="Kuruluş Adı" field="onayliKurulusAd" value={form.onayliKurulusAd} error={errors.onayliKurulusAd} onChange={set} />
        <Field label="Kuruluş No" field="onayliKurulusNo" value={form.onayliKurulusNo} error={errors.onayliKurulusNo} onChange={set} />
        <Field label="Sanayi Tarih" field="sanayiTarih" value={form.sanayiTarih} error={errors.sanayiTarih} onChange={set} />
        <Field label="Sanayi No" field="sanayiNo" value={form.sanayiNo} error={errors.sanayiNo} onChange={set} />
        <Field label="HYB Tarih" field="hybTarih" value={form.hybTarih} error={errors.hybTarih} onChange={set} />
        <Field label="HYB No" field="hybNo" value={form.hybNo} error={errors.hybNo} onChange={set} />
      </Section>

      <Section title="Makina Mühendisi">
        <Field label="Ad Soyad" field="makinaMuhAd" value={form.makinaMuhAd} error={errors.makinaMuhAd} onChange={set} />
        <Field label="Oda Sicil No" field="makinaMuhOdaSicil" value={form.makinaMuhOdaSicil} error={errors.makinaMuhOdaSicil} onChange={set} />
        <Field label="Belge No" field="makinaMuhBelge" value={form.makinaMuhBelge} error={errors.makinaMuhBelge} onChange={set} />
        <Field label="SMM No" field="makinaMuhSMM" value={form.makinaMuhSMM} error={errors.makinaMuhSMM} onChange={set} />
      </Section>

      <Section title="Elektrik Mühendisi">
        <Field label="Ad Soyad" field="elektrikMuhAd" value={form.elektrikMuhAd} error={errors.elektrikMuhAd} onChange={set} />
        <Field label="Oda Sicil No" field="elektrikMuhOdaSicil" value={form.elektrikMuhOdaSicil} error={errors.elektrikMuhOdaSicil} onChange={set} />
        <Field label="Belge No" field="elektrikMuhBelge" value={form.elektrikMuhBelge} error={errors.elektrikMuhBelge} onChange={set} />
        <Field label="SMM No" field="elektrikMuhSMM" value={form.elektrikMuhSMM} error={errors.elektrikMuhSMM} onChange={set} />
      </Section>
    </div>
  )
}

function Section({ title, children }: { title: string; children: React.ReactNode }) {
  return (
    <div className="card" style={{ marginBottom: 24 }}>
      <h2 style={{ marginBottom: 16 }}>{title}</h2>
      <div className="grid grid-3">{children}</div>
    </div>
  )
}

function Field({ label, field, value, error, onChange }: {
  label: string; field: string; value?: string; error?: string
  onChange: (key: string, val: string) => void
}) {
  return (
    <div>
      <label>{label}</label>
      <input value={value || ''} onChange={e => onChange(field, e.target.value)}
        style={error ? { borderColor: 'var(--danger)' } : {}} />
      {error && <span style={{ color: 'var(--danger)', fontSize: 12 }}>{error}</span>}
    </div>
  )
}
